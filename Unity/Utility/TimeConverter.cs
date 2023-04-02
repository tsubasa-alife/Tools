using System;
using UnityEngine;

public class TimeConverter
{
	public static string SecondsToMinutes(float timeSeconds)
	{
		int minutes = (int)timeSeconds / 60;
		float seconds = timeSeconds - minutes * 60;
		return minutes.ToString("00") + ":" + ((int)seconds).ToString("00");
	}
}



