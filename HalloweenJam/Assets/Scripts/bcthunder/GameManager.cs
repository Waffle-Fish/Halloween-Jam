using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    // Managing the Customers
    public float[] orderTimers = { 45, 45, 45 };
    public float[] customerSpawnerTime = { 15, 15, 15 };

    public CustomerSpawner[] customerSpawners = new CustomerSpawner[] {null, null, null};
    public GameObject[] customers = {null, null, null};
    public Potion[] customerPotions = { null, null, null };
    bool isCustomerSpawned;

    // Managing Points
    public int pointsPerPotion = 10;
    public int pointsLost = 5;
    public int totalPoints = 0;

    // Level Duration
    public float levelDuration = 420;

    private void Awake() {
        if (Instance != null && Instance != this) Destroy(this); 
        else Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelDuration >= 0) 
        {
            // Handling Customer Spawns
            for (int i = 0; i < customers.Length; i++ )
            {
                // If there is a customer, countdown their order time, else countdown their spawn time
                if (customers[i] != null) {
                    orderTimers[i] -= Time.deltaTime;
                } else {
                    customerSpawnerTime[i] -= Time.deltaTime;
                }

                // If the order countdown finishes, customer leaves
                if (orderTimers[i] <= 0) {
                    Debug.Log("Customer " + i + " Removed");
                    RemoveCustomer(i);
                }

                // If the customer spawn time finishes, spawn the customer
                if (customerSpawnerTime[i]  <= 0) {
                    customerSpawnerTime[i] = 15;
                    customerSpawners[i].SpawnCustomer();
                    customers[i] = customerSpawners[i].GetCustomer();
                }

                // // If the player gives the customer the right Potion score points, else "trash" the potion
                // if (customerPotions[i] != null) {
                //     CustomerBehavior customerToCheck = customerPotions[i].GetComponent<CustomerBehavior>();
                //     if (customerToCheck.order.orderedPotion == customerPotions[i])
                //     {
                //         ScorePoints();
                //         RemoveCustomer(i);
                //     }
                //     else
                //     {
                //         customerPotions[i] = null;
                //     }
                // }
            }

            levelDuration -= Time.deltaTime;

        } else 
        {
            GameOver();
        }
    }

    public void RemoveCustomer(int index)
    {   
        customerSpawners[index].RemoveCustomer();
        customers[index] = null;
        orderTimers[index] = 45;
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        AudioManager.Instance.musicSource.Stop();
        SceneManager.LoadScene("GameOver");
    }

    public void ScorePoints() { totalPoints += pointsPerPotion; }
    public void LosePoints() { totalPoints -= pointsLost; }

    // If customer, call this function to find where you are in the index
    public int FindSelf(GameObject customerToFind) {
        int ind;
        for (ind = 0; ind < customers.Length; ind++) {
            if ((customers[ind]) == customerToFind) return ind;
        }
        return -1;
    }
}
