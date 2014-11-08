using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

/**
 * This class holds information about one single shot
*/
public class Shot {
    private int start_frame;
    private double start_time;//optional
    private List<String> tags;

    public Shot(int start_frame, double start_time) {
        this.start_frame = start_frame;
        this.start_time = start_time;
        tags = new List<String>();
    }
    public Shot(int start_frame) : this(start_frame, 0) { }

    public void addTag(string tag) {
        tags.Add(tag);
    }

    public List<String> getTagArray() {
        return this.tags;
    }
    public string getTags() {
        if (tags.Count == 0){
            return "";
        }else{
            String s = (String)tags[0];
            for (int i = 1; i < tags.Count ; i++)
                s += "," + tags[i];
            return s;
        }
    }

    public double getStartTime() {
        return start_time;
    }

    public int getStartFrame() {
        return start_frame;
    }

    public void writeFile(string filename) {
        //TODO write to xml/csv/json format?
    }

    public void writeConsole() {
        Console.Write("Shot at " + start_frame + "has tags: ");
        for (int i = 0; i < tags.Count; i++)
            Console.Write(tags[i] + "\t");
        Console.WriteLine();
    }
}

