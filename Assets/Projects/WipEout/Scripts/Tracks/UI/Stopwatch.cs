using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stopwatch : MonoBehaviour
{
    public float fastestTime;
    public float currentTime;
    [Space]
    public UnityEvent NewLapRecord;

    private bool x = true;

    public void newLap ()
    {
        stopTimer();
        compareTimes();
        resetTimer();
        startTimer();
    }

    public void startTimer ()
    {
        StartCoroutine("runTimer");
    }

    public void stopTimer ()
    {
        StopCoroutine("runTimer");
    }

    public void compareTimes ()
    {
        if (fastestTime == 0)
        {
            newLapRecord();
        }
        else if (currentTime < fastestTime)
        {
            newLapRecord();
        }
    }

    public void newLapRecord ()
    {
        fastestTime = currentTime;
        NewLapRecord.Invoke();
    }

    public void resetTimer ()
    {
        currentTime = 0.0f;
    }

    public IEnumerator runTimer ()
    {
        while (x)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }
    }
}
