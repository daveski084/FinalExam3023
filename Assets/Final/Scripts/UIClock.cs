using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIClock : MonoBehaviour, ITimeObserver
{
    //Singleton
    public static UIClock instance { get; private set; }
    public Text timeText;
    public Text dateText;
    public Text yearText;

    private void Awake()
    {
        // If there is more than one instance destroy it
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }


    //Add this class to the list of observers
    void Start()
    {
        ClockManager.timeInstance.ResgisterListener(this);
    }


    public void ClockUpdate(TimeManager timeStamp)
    {

        int hours = timeStamp.hour;
        int minutes = timeStamp.minute;
        string timePreFix = "AM ";

        //convert values to 12 hour clock
        if(hours > 12)
        {
            timePreFix = "PM ";
            hours = hours - 12;
        }

        //Formatting the time 
        timeText.text = timePreFix + hours + ":" + minutes.ToString("00");

        // Date
        int day = timeStamp.day;
        string season = timeStamp.season.ToString();
        string dayOfTheWeek = timeStamp.GetDayOfTheWeek().ToString();
        string year = timeStamp.year.ToString();

        //formatting the date
        dateText.text = season + " " + day + " (" + dayOfTheWeek + ") ";

        //formatting the year
        yearText.text = "Year: " + year;

    }
   
}
