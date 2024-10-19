using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float maxCookingTime;
    public float cookTimePerIngredient;

    private float countdownTimer;

    public bool isCountingDown = false;
    private bool isTimerFinished = false;

    public string timerName;

    // Update is called once per frame
    void Update()
    {
        if (isCountingDown)
        {
            CountdownTimer();
        }

        if (countdownTimer <= 0)
        {
            StopCountdown();
            isTimerFinished = true;

        }
    }

    // Countdown the timer to zero
    public void CountdownTimer() { countdownTimer -= Time.deltaTime; }

    public void ResetTimer()
    {
        countdownTimer = maxCookingTime;
        isTimerFinished = false;
    }

    public void StartCountdown()
    {
        if (!isCountingDown) { isCountingDown = true; }
    }

    public void StopCountdown()
    {
        if (isCountingDown) { isCountingDown = false;}
    }

    public bool IsTimerCountingDown()
    {
        return isCountingDown;
    }

    public bool CheckTimerFinished()
    {
        return isTimerFinished;
    }


}
