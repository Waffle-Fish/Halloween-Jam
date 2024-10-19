using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Managing the Customers
    public static float[] orderTimers = { 45, 45, 45 };
    public static float[] customerSpawnerTime = { 15, 15, 15 };

    public static CustomerSpawner[] customerSpawners = {new CustomerSpawner(), new CustomerSpawner(), new CustomerSpawner()};
    public static CustomerBehavior[] customers = {null, null, null};
    public static Potion[] customerPotions = { null, null, null };
    bool isCustomerSpawned;

    // Managing Points
    public int pointsPerPotion = 10;
    int totalPoints = 0;

    // Level Duration
    public float levelDuration = 360;

    // Start is called before the first frame update
    void start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Handling Customer Spawns
        for (int i = 0; i < customers.Length; i++ )
        {
            // If there is a customer, countdown their order time, else countdown their spawn time
            if (customers[i] != null) {
                orderTimers[i] -= Time.deltaTime;
            } else {
                customerSpawnerTime -= Time.deltaTime;
            }

            // If the order countdown finishes, customer leaves
            if (orderTimers[i] <= 0) {
                RemoveCustomer(i);
            }

            // If the customer spawn time finishes, spawn the customer
            if (customerSpawnerTime[i]  <= 0) {
                customerSpawnerTime[i] = 15;
                customers[i] = customerSpawners[i].SpawnCustomer();
            }

            // If the player gives the customer the right Potion score points, else "trash" the potion
            if (customerPotions[i] != null) {
                if (customers[i].order.orderedPotion == customerPotions[i])
                {
                    ScorePoints();
                }
                else
                {
                    customerPotions[i] = null;
                }
            }
        }
    }

    void RemoveCustomer(int index)
    {
        Destroy(customers[index], 2);
        orderTimers[index] = 45;
    }

    void ScorePoints() { totalPoints += pointsPerPotion; }

}
