using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Interface for observers
/// </summary>
public interface IShotObserver {
    /// <summary>
    /// A new shot is detected
    /// </summary>
    /// <param name="shot">the newly detected shot</param>
    void updateList(Shot shot);
}