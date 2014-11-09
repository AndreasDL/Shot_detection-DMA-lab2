using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Interface for observers
/// </summary>
public interface IObserver {
    /// <summary>
    /// A new shot is detected
    /// </summary>
    /// <param name="shot">the newly detected shot</param>
    void updateList(Shot shot);
    /// <summary>
    /// Next frame is handled
    /// </summary>
    /// <param name="frameNumber">the number of the new frame</param>
    void updateTrackbar(int frameNumber);
}