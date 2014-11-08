using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IObserver {
    void updateList(Shot shot);
    void updateTrackbar(int frameNumber);
}