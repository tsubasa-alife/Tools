using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 実機上でログを表示するためのクラス
/// ScrollViewを用意して使用する
/// </summary>

public class LogViewer : MonoBehaviour
{
    public Text message = null;

    private void Awake()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDestroy()
    {
        Application.logMessageReceived -= HandleLog;
    }

    private void HandleLog(string logText, string stackTrace, LogType type)
    {
        message.text += logText + "\n" + stackTrace + "\n";
    }
}
