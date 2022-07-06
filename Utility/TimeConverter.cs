using System;
using UnityEngine;
public class TimeConverter<T> where T : IComparable
{
    public void SecondsToMinutes(T timeSeconds)
    {
        int minutes = (int)timeSeconds / 60;
        float seconds = timeSeconds - minutes * 60;
        Debug.Log(minutes.ToString("00") + ":" + ((int)seconds).ToString("00");
    }
}



