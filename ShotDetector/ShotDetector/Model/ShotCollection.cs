using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShotCollection{
    private string videoName; //optional
    private ArrayList shots;
    private ArrayList observers;

    public ShotCollection(): this("") {}
    public ShotCollection(string videoName) {
        this.shots = new ArrayList();
        this.videoName = videoName;
        this.observers = new ArrayList();
    }

    public void setVideoName(string name) {
        this.videoName = name;
    }

    public void addShot(Shot shot) {
        shots.Add(shot);
        notifyObservers(shot); //update all observers
    }
    public ArrayList getShots() {
        return this.shots;
    }

    public void addObserver(IObserver obs) {
        observers.Add(obs);
    }

    private void notifyObservers(Shot shot) {
        foreach (IObserver o in observers)
            o.updateList(shot);
    }

}
