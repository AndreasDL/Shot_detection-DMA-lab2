using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// elements that want notifications of new detected frames should implement this interface and then add themselves as observers.
/// </summary>
public interface IFrameObserver {
    void updateProgress(long frameNumber);
}
