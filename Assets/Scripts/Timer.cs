using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float totalSeconds = 0;
    float elapsedSecond = 0;
    bool isRunning = false;
    bool isStarted = false;

    public float Duration
    {
        set
        {
            if (!isRunning)
            {
                totalSeconds = value;
            }
        }
    }

    public bool Finished
    {
        get { return isStarted && !isRunning; }
    }

    public bool Running
    {
        get { return isRunning; }
    }

    public void Run()
    {
        if (totalSeconds > 0)
        {
            isStarted = true;
            isRunning = true;
            elapsedSecond = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            elapsedSecond = elapsedSecond + Time.deltaTime;
            if (elapsedSecond >= totalSeconds)
            {
                isRunning = false;
            }
        }
    }
}