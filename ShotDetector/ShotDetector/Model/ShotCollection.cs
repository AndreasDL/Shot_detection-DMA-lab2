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
    private Dictionary<String, Object> parameters;
    private String videoFileName;
    private int methodNumber;

    public ShotCollection(int methodNumber) {
        this.shots = new List<Shot>();
        this.observers = new List<IShotObserver>();
        this.parameters = new Dictionary<String, object>();
        this.methodNumber = methodNumber;
    }
    public ShotCollection(string fileName):this(0) { 
        XmlDocument doc = new XmlDocument();
        doc.Load(fileName);

        XmlNodeList elemList = doc.GetElementsByTagName("shot");
        for (int i = 0; i < elemList.Count; i++) {
            String line = elemList[i].InnerText;
            line = line.Substring(0, line.IndexOf("-"));

            addShot(new Shot(Convert.ToInt32(line), i));
        } 
    }

    public void addParameter(String name,Object parameter) {
        parameters.Add(name,parameter);
    }
    public void setLastFrame(long frameCount) {
        shots.Add(new Shot((int)frameCount , shots.Count));
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
        
        XmlNode method = doc.CreateElement("method");
        XmlAttribute nr = doc.CreateAttribute("nr");
        nr.Value = Convert.ToString(methodNumber);
        method.Attributes.Append(nr);


        //method name
        XmlAttribute methodName = doc.CreateAttribute("methodName");
        methodName.Value = MethodFactory.METHODS[this.methodNumber - 1];
        method.Attributes.Append(methodName);
        
        //params
        int pnr = 0;
        foreach(KeyValuePair<String,Object> entry in parameters){
            XmlNode param = doc.CreateElement("param" + pnr);
            param.InnerText = Convert.ToString(entry.Value);

            XmlAttribute paramName = doc.CreateAttribute("name");
            paramName.Value = entry.Key;
            param.Attributes.Append(paramName);

            method.AppendChild(param);
            pnr++;
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

    public List<Shot> searchShots(string tag) {
        List<Shot> results = new List<Shot>();

        //lineair search, check which frames have the tag, can be optimized using more complex data structures, however i think this overkill.
        //The focus of this application is to do the shot detection on small clips, managing a huge collection of movie requires databases and semantics to search for the tags
        foreach( Shot s in this.shots){
            List<String> tags = s.getTagArray();
            int j = 0;
            while (j < tags.Count && tags[j] != tag) { //while not found
                j++;
            }

            //if found, save
            if (j != tags.Count) {
                results.Add(s);
            }
        }

        return results;
    }
}
