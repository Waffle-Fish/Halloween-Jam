using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Managing the Customers
    float customerSpawnTime = 10;
    bool isTimerCountingDown = false;

    CustomerSpawner spawner;
    CustomerBehavior customer;
    bool isCustomerSpawned;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewCustomer();
    }

    // Update is called once per frame
    void Update()
    {
        // If Customer hasn't spawned and the spawn timer is not active, start countdown to spawn new customer
        if (!isCustomerSpawned && !isTimerCountingDown)
        {
            isTimerCountingDown=true;
        }


        // If spawn timer is active, countdown
        if (isTimerCountingDown)
        {
            countDown();

            // When countdown is complete, spawn a new customer and reset the timer
            if (customerSpawnTime <= 0)
            {
                SpawnNewCustomer();
                ResetTimer();
            }
        }
    }

    void ResetTimer()
    {
        isTimerCountingDown = false;
        customerSpawnTime = 10; 
    }

    void SpawnNewCustomer ()
    {
        spawner.SpawnCustomer();
        if (spawner.customer != null)
        {
            isCustomerSpawned = true;
            customer = spawner.customer;
        }
    }

    void countDown()
    {
        customerSpawnTime -= Timer.detlaTime;
    }
}
