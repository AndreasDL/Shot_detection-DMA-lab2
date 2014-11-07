using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShotCollection{
    private string videoName; //optional
    private ArrayList shots;

    public ShotCollection(): this("") {}
    public ShotCollection(string videoName) {
        this.shots = new ArrayList();
        this.videoName = videoName;
    }

    public void setVideoName(string name) {
        this.videoName = name;
    }

    public void addShot(Shot shot) {
        shots.Add(shot);
    }
    public ArrayList getShots() {
        return this.shots;
    }

}
