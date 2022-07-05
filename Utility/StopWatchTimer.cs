using UnityEngine;

public class StopWatchTimer : MonoBehaviour
{
    private float currentTime;
    public bool isTimerActive = false;

    void Update()
    {
        if(isTimerActive)
        {
            currentTime += Time.deltaTime;
        }
    }

    public void OnStart()
    {
        isTimerActive = true;
    }
    public void OnStop()
    {
        isTimerActive = false;
    }
    public void OnReset()
    {
        currentTime = 0.0f;
        isTimerActive = false;
    }
}
