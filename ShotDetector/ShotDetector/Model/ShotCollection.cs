using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

/// <summary>
/// Collection of the detected shots
/// </summary>
public class ShotCollection{
    private List<Shot> shots; //list of the shots
    private List<IShotObserver> observers; //list of the observers
    private int method;
    private List<Object> parameters;
    private long lastFrame;
    private String videoFileName;

    public ShotCollection() {
        this.shots = new List<Shot>();
        this.observers = new List<IShotObserver>();
        this.parameters = new List<Object>();
    }
    public ShotCollection(string fileName):this() { 
        XmlDocument doc = new XmlDocument();
        doc.Load(fileName);

        XmlNodeList elemList = doc.GetElementsByTagName("shot");
        for (int i = 0; i < elemList.Count; i++) {
            String line = elemList[i].InnerText;
            line = line.Substring(0, line.IndexOf("-"));

            addShot(new Shot(Convert.ToInt32(line), i));
        } 
    }

    public void setMethod(int method) {
        this.method = method;
    }

    public void addParameter(Object parameter) {
        parameters.Add(parameter);
    }
    public void setLastFrame(long frameCount) {
        //fix for the last shot
        lastFrame = frameCount;
        addShot(new Shot((int)frameCount , shots.Count));
    }

    public void setfile(string videoFileName) {
        this.videoFileName = videoFileName;
    }

    /// <summary> exports the data struct to xml </summary>
    /// <param name="fileName">the path of the output file</param>
    public void export(string fileName) {
        XmlDocument doc = new XmlDocument();
        
        //root
        XmlNode root = doc.CreateElement("Shotdetection");
        XmlAttribute file = doc.CreateAttribute("file");
        file.Value = videoFileName;
        root.Attributes.Append(file);
        doc.AppendChild(root);

        //method number
        XmlNode method = doc.CreateElement("method");
        XmlAttribute nr = doc.CreateAttribute("nr");
        nr.Value = Convert.ToString(this.method + 1);
        method.Attributes.Append(nr);
        //method name
        XmlAttribute methodName = doc.CreateAttribute("methodName");
        methodName.Value = MethodFactory.METHODS[this.method];
        method.Attributes.Append(methodName);
        
        //params
        for (int i = 0; i < parameters.Count; i++) {
            XmlNode param = doc.CreateElement("param" + i);
            param.InnerText = Convert.ToString(this.parameters[i]);
            method.AppendChild(param);
        }
        root.AppendChild(method);

        //shots
        XmlNode shots = doc.CreateElement("shots");
        for (int i = 0; i < this.shots.Count - 1; i++) {
            XmlNode shot = doc.CreateElement("shot");
            shot.InnerText = this.shots[i].getStartFrame() + "-" + (this.shots[i + 1].getStartFrame() - 1);
            shots.AppendChild(shot);
        }
        root.AppendChild(shots);

        //tags
        XmlNode tagList = doc.CreateElement("shotDetails");
        for (int i = 0; i < this.shots.Count - 1; i++) {
            //all tags of a frame
            XmlNode tags = doc.CreateElement("shotDetail");
            
            XmlAttribute frameNumber = doc.CreateAttribute("shotNumber");
            frameNumber.Value = "" + i;
            tags.Attributes.Append(frameNumber);
            XmlAttribute startFrame = doc.CreateAttribute("startFrame");
            startFrame.Value = "" + this.shots[i].getStartFrame();
            tags.Attributes.Append(startFrame);
            XmlAttribute stopFrame = doc.CreateAttribute("stopFrame");
            stopFrame.Value = "" + (this.shots[i + 1].getStartFrame() -1);
            tags.Attributes.Append(stopFrame);

            foreach (String t in this.shots[i].getTagArray()) {
                XmlNode tag = doc.CreateElement("tag");
                tag.InnerText = t;
                tags.AppendChild(tag);
            }
            tagList.AppendChild(tags);
        }
        root.AppendChild(tagList);

        doc.Save(fileName);
    }

    /// <summary>
    /// adds a shot to the collection
    /// </summary>
    /// <param name="shot">the shot to add</param>
    public void addShot(Shot shot) {
        shots.Add(shot);
        notifyObservers(shot); //update all observers
    }
    /// <summary>
    /// returns a list of shots
    /// </summary>
    /// <returns>the list of shots</returns>
    public List<Shot> getShots() {
        return this.shots;
    }
    /// <summary>
    /// Adds an observer
    /// </summary>
    /// <param name="obs">observer to add</param>
    public void addObserver(IShotObserver obs) {
        observers.Add(obs);
    }
    /// <summary>
    /// notifies the observers when a new shot is detected
    /// </summary>
    /// <param name="shot">the newly detected shot</param>
    private void notifyObservers(Shot shot) {
        foreach (IShotObserver o in observers)
            o.updateList(shot);
    }
    /// <summary>
    /// calculate the recall
    /// </summary>
    /// <param name="truth">the ground truth collection</param>
    /// <returns>the recall</returns>
    public double calcRecall(ShotCollection truth) {
        int truthCount = 0;

        int indexTruth = 0;
        int indexResults = 0;

        while (indexResults < this.shots.Count) {
            //move indextruth until there is a possible match
            while (indexTruth < truth.shots.Count - 1
                && truth.getShot(indexTruth).getStartFrame() < getShot(indexResults).getStartFrame()) {
                indexTruth++;
            }

            //kijken of het overeen komt
            if (truth.getShot(indexTruth).getStartFrame() == getShot(indexResults).getStartFrame()) {
                truthCount++;
            }

            indexResults++;
        }
        
        return this.shots.Count > 0 ? (1.0 * truthCount) / (this.shots.Count) : 0 ;
    }
    /// <summary>
    /// calculates the precision
    /// </summary>
    /// <param name="truth">the ground truth collection</param>
    /// <returns>the precision</returns>
    public double calcPrecision(ShotCollection truth) {
        
        int truthCount = 0;

        int indexTruth = 0;
        int indexResults = 0;

        while (indexResults < this.shots.Count) {
            //move indextruth until there is a possible match
            while (indexTruth < truth.shots.Count - 1
                && truth.getShot(indexTruth).getStartFrame() < getShot(indexResults).getStartFrame()) {
                indexTruth++;
            }

            //kijken of het overeen komt
            if (truth.getShot(indexTruth).getStartFrame() == getShot(indexResults).getStartFrame()) {
                truthCount++;
            }

            //move indexResults until there is a possible match
            indexResults++;
        }

        return (1.0 * truthCount) / (truth.getShots().Count);
    }
    /// <summary>
    /// returns the shot at a given index
    /// </summary>
    /// <param name="index">the index</param>
    /// <returns>shot at index 'index'</returns>
    public Shot getShot(int index) { 
        return this.shots[index];
    }
    /// <summary>
    /// Clear all the shots
    /// </summary>
    public void clear() {
        shots.Clear();
    }
}
