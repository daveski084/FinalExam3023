using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimeManager
{
    public enum WeekDay
    {
        Saturday,
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }
    public enum Season
    {
        SPRING,
        SUMMER,
        AUTUMN,
        WINTER
    }

    public int year, day, hour, minute;
    public Season season;

    //constructor
    public TimeManager(int year, Season season, int day, int hour, int minute)
    {
        this.year = year;
        this.season = season;
        this.day = day;
        this.hour = hour;
        this.minute = minute;
    }

    //Converting Functions:
    public WeekDay GetDayOfTheWeek()
    {
        //Convert the the time that has passed in gamne to days
        int daysPassed = YearsToDays(year) + SeasonsToDays(season) + day;
        int dayIndex = daysPassed % 7;

        return (WeekDay)dayIndex;
    }


    public static int YearsToDays(int years)
    {
        return years * 4 * 30;
    }
    public static int SeasonsToDays(Season season)
    {
        int seasonalIndex = (int)season;
        return seasonalIndex * 30;
    }

    public static int DaysToHours(int days)
    {
        return days * 24;
    }

    public static int HoursToMinutes(int hour)
    {
        return hour * 60;
    }


    public void UpdateTime()
    {
        minute++;

        // Reset the minutes to 0 after 60 min has passed, increment the hour.
        if(minute >= 60)
        {
            minute = 0;
            hour++;
        }

        // Reset the hours back to midnight after 24 hours. Incement the day.
        if(hour >= 24)
        {
            hour = 0;
            day++;
        }

        if( day > 30)
        {
            // Reset the day back to the first, start of a new month. 
            day = 1;

            // Update seasons
            if(season == Season.WINTER)
            {
                season = Season.SPRING;
                //New year
                year++;
            }
            //new season
            season++;
        }
       
    }
    
}
