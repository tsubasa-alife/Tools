using System;
using System.IO;
using UnityEngine;
using UnityEditor;
// スクリーンショット撮影用エディタ拡張
public class Screenshot
{
    [MenuItem("Tools/Screenshot")]
    public static void CaptureGameScreen()
    {
        string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Screenshot");

        if(!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        DateTime date = DateTime.Now;
        string fileName = "screenshot_" + date.ToString($"{date:yyyyMMddHHmm}") + ".png";
        string savePath = Path.Combine(folderPath, fileName);
        ScreenCapture.CaptureScreenshot(savePath);
    }
}
