using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimeObserver 
{
    void ClockUpdate(TimeManager timeStamp);

}
