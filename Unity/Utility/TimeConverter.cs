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

	public static string SecondsToHours(float timeSeconds)
	{
		int hours = (int)timeSeconds / 3600;
		int minutes = (int)(timeSeconds - hours * 60) / 60;
		float seconds = timeSeconds - hours * 3600 - minutes * 60;
		return hours.ToString("00") + ":" + minutes.ToString("00") + ":" + ((int)seconds).ToString("00");
	}
}



