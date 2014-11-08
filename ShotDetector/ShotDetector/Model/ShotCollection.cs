using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShotCollection{
    private List<Shot> shots;
    private List<IObserver> observers;

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

    public void addShot(Shot shot) {
        shots.Add(shot);
        notifyObservers(shot); //update all observers
    }
    public List<Shot> getShots() {
        return this.shots;
    }

    public void addObserver(IObserver obs) {
        observers.Add(obs);
    }

    private void notifyObservers(Shot shot) {
        foreach (IObserver o in observers)
            o.updateList(shot);
    }

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

    public Shot getShot(int index) { 
        return this.shots[index];
    }

    public void clear() {
        shots.Clear();
    }
}
