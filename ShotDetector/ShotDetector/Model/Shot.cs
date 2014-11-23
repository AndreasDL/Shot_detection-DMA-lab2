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
    private List<String> tags;//list of the tags defined by the user
    private int shotNumber;

    /// <summary>
    /// Constructor that creates a shot
    /// </summary>
    /// <param name="start_frame">the number of the start frame of the shot</param>
    /// <param name="start_time">the start time of the shot in seconds</param>
    public Shot(int start_frame, int shotNumber) {
        this.start_frame = start_frame;
        this.shotNumber = shotNumber;
        tags = new List<String>();
    }

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
    /// returns the number of the start frame
    /// </summary>
    /// <returns>framenumber of the start frame</returns>
    public int getStartFrame() {
        return start_frame;
    }

    public int getShotNumber() {
        return shotNumber;
    }

    public String getTagString() {
        String s = "";
        foreach (String tag in this.tags) {
            s += tag + ";";
        }

        return s;
    }

    public void setTagString(String tags) {
        this.tags = new List<String>(tags.Split(';'));
    }
}

