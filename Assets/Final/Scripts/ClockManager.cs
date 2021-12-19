using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    //Singleton
    public static ClockManager timeInstance { get; private set;}

    [SerializeField]
    TimeManager timeStamp;
    public float lengthOfTime = 1.0f;

    //Observers
    List<ITimeObserver> listeners = new List<ITimeObserver>(); 

    private void Awake()
    {
        // If there is more than one instance destroy it
        if(timeInstance != null && timeInstance != this)
        {
            Destroy(this);
        }
        else
        {
            timeInstance = this;
        }
    }

    private void Start()
    {
        timeStamp = new TimeManager(0, TimeManager.Season.SPRING, 1, 6, 0);
        StartCoroutine(UpdateTheTime()); 
    }

    IEnumerator UpdateTheTime()
    {
        while(true)
        {
            Tick();
            yield return new WaitForSeconds(1/lengthOfTime);
        }
    }


    //Tick to move in game time
    public void Tick()
    {
        timeStamp.UpdateTime(); 

        foreach(ITimeObserver listerner in listeners)
        {
            listerner.ClockUpdate(timeStamp);
        }
    }

    //Add listener to list
    public void ResgisterListener(ITimeObserver listener)
    {
        listeners.Add(listener);
    }

    //Remove listener
    public void DeregisterListener(ITimeObserver listener)
    {
        listeners.Remove(listener);
    }

}
