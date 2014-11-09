using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

/// <summary>
/// This class holds information about one single shot
/// </summary>
public class Shot {
    private int start_frame;  //Start_frame number of the shot
    private double start_time;//start time of the shot (optional)
    private List<String> tags;//list of the tags defined by the user
    /// <summary>
    /// Constructor that creates a shot
    /// </summary>
    /// <param name="start_frame">the number of the start frame of the shot</param>
    /// <param name="start_time">the start time of the shot in seconds</param>
    public Shot(int start_frame, double start_time) {
        this.start_frame = start_frame;
        this.start_time = start_time;
        tags = new List<String>();
    }
    public Shot(int start_frame) : this(start_frame, 0) { }

    /// <summary>
    /// Add a tag to the shot
    /// </summary>
    /// <param name="tag">the tag to add</param>
    public void addTag(string tag) {
        tags.Add(tag);
    }
    /// <summary>
    /// Returns the saved tags
    /// </summary>
    /// <returns>list of the tags</returns>
    public List<String> getTagArray() {
        return this.tags;
    }

    /// <summary>
    /// return the saved tags in a single string
    /// </summary>
    /// <returns>tag1,tag2,tag2...</returns>
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

    /// <summary>
    /// returns the number of the start frame
    /// </summary>
    /// <returns>framenumber of the start frame</returns>
    public int getStartFrame() {
        return start_frame;
    }

    /// <summary>
    /// writes the contents to the console (debugging purposes only)
    /// </summary>
    public void writeConsole() {
        Console.Write("Shot at " + start_frame + "has tags: ");
        for (int i = 0; i < tags.Count; i++)
            Console.Write(tags[i] + "\t");
        Console.WriteLine();
    }
}

