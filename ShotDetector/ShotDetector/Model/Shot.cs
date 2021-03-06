﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;

/// <summary>
/// This class holds information about one single shot
/// </summary>
public class Shot {
    private int startFrame;  //Start_frame number of the shot
    private List<String> tags;//list of the tags defined by the user
    private int shotNumber;
    private Bitmap frameShot;

    /// <summary>
    /// Constructor that creates a shot
    /// </summary>
    /// <param name="startFrame">the number of the start frame of the shot</param>
    /// <param name="start_time">the start time of the shot in seconds</param>
    public Shot(int startFrame, int shotNumber, Bitmap frameShot) {
        this.startFrame = startFrame;
        this.shotNumber = shotNumber;
        tags = new List<String>();
        this.frameShot = frameShot;
    }

    // constructor without bitmap
    public Shot(int startFrame, int shotNumber): this(startFrame, shotNumber, null){}

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
        return startFrame;
    }

    /// <summary>
    /// return the number of the shot
    /// </summary>
    /// <returns>number of the shot</returns>
    public int getShotNumber() {
        return shotNumber;
    }

    /// <summary>
    /// returns the tag string
    /// </summary>
    /// <returns>a string that holds all the tags, separated with a ';'</returns>
    public String getTagString() {
        String s = "";
        foreach (String tag in this.tags) {
            s += tag + ";";
        }

        return s;
    }

    /// <summary>
    /// get a new tag string e.g. when it is changed in gui
    /// </summary>
    /// <param name="tags">the tag string, formatted as follows: tag1;tag2;tag3; ...</param>
    public void setTagString(String tags) {
        tags = tags.Replace("\n","");//remove newlines
        this.tags = new List<String>(tags.Split(';'));
    }

    /// <summary>
    /// return the frame that represents the shot
    /// </summary>
    /// <returns>the bitmap</returns>
    public Bitmap getFrameShot() {
        return this.frameShot;
    }

    /// <summary>
    /// save a bitmap
    /// </summary>
    /// <param name="frameShot">the bitmap</param>
    public void setBitmap(Bitmap frameShot) {
        this.frameShot = frameShot;
    }
}

