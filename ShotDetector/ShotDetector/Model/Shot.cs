using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

/**
 * This class holds information about one single shot
*/
public class Shot {
    private int start_frame;
    private double start_time;
    private ArrayList tags;

    public Shot(int start_frame, double start_time) {
        this.start_frame = start_frame;
        this.start_time = start_time;
        tags = new ArrayList();
    }

    public void addTag(string tag) {
        tags.Add(tag);
    }

    public ArrayList getTags() {
        return this.tags;
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

