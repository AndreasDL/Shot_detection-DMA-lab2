using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Collection of the detected shots
/// </summary>
public class ShotCollection{
    private List<Shot> shots; //list of the shots
    private List<IObserver> observers; //list of the observers 


    public ShotCollection() {
        this.shots = new List<Shot>();
        this.observers = new List<IObserver>();
    }
    public ShotCollection(string fileName):this() { 
        //TODO use xml parser?

        //open file
        string[] lines = System.IO.File.ReadAllLines(fileName);
        //parse results
        for (int i = 2; i < lines.Length; i++) {
            if (lines[i].Substring(0, 10) == "    <shot>") {
                string line = lines[i].Substring(10, lines[i].Length - 17);
                line = line.Substring(0, line.IndexOf("-"));
                
                //add to colection
                addShot(new Shot( Convert.ToInt32(line) ));
            }
        }
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
    public void addObserver(IObserver obs) {
        observers.Add(obs);
    }
    /// <summary>
    /// notifies the observers when a new shot is detected
    /// </summary>
    /// <param name="shot">the newly detected shot</param>
    private void notifyObservers(Shot shot) {
        foreach (IObserver o in observers)
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
            while (indexTruth < truth.shots.Count && truth.getShot(indexTruth).getStartFrame() < getShot(indexResults).getStartFrame()) {
                indexTruth++;
            }

            //kijken of het overeen komt
            if (truth.getShot(indexTruth).getStartFrame() == getShot(indexResults).getStartFrame()) {
                truthCount++;
            }

            //move indeResults until there is a possible match
            indexResults++;
        }

        return (1.0*truthCount) / (truth.getShots().Count);
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
            while (indexTruth < truth.shots.Count 
                && truth.getShot(indexTruth).getStartFrame() < getShot(indexResults).getStartFrame()) {
                indexTruth++;
            }

            //kijken of het overeen komt
            if (truth.getShot(indexTruth).getStartFrame() == getShot(indexResults).getStartFrame()) {
                truthCount++;
            }

            indexResults++;
        }

        return (1.0 * truthCount) / (this.shots.Count);
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
