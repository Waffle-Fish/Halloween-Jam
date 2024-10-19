using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float maxTime;
    private float countdownTimer;
    public bool isCountingDown = false;

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
    }

    // Countdown the timer to zero
    public void CountdownTimer() { countdownTimer -= Time.deltaTime; }

    public void StartCountdown()
    {
        if (!isCountingDown) { isCountingDown = true; }
    }

    public bool IsTimeCountingDown()
    {
        return isCountingDown;
    }

    public void StopCountdown()
    {
        if (isCountingDown) { isCountingDown = false;}
    }

}
