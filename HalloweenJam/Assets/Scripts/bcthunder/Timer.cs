using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float maxTime;
    private float countdownTimer;
    public bool isCountingDown = false;
    private bool isTimerFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        float countdown = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountingDown)
        {
            CountdownTimer();
        }

        if (countdownTimer == 0)
        {
            StopCountdown();
            isTimerFinished = true;

        }
    }

    // Countdown the timer to zero
    public void CountdownTimer() { countdownTimer -= Time.deltaTime; }

    public void ResetTimer()
    {
        countdownTimer = maxTime;
    }

    public void StartCountdown()
    {
        if (!isCountingDown) { isCountingDown = true; }
    }

    public void StopCountdown()
    {
        if (isCountingDown) { isCountingDown = false;}
    }

    public bool IsTimeCountingDown()
    {
        return isCountingDown;
    }

    public bool CheckTimerFinished()
    {
        return isTimerFinished;
    }


}
