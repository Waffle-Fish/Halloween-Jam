using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab;

    public CustomerBehavior customer;

    void start()
    {
        
    }

    void SpawnCustomer()
    {
        customer = Instantiate(customerPrefab, transform.position, Quaternion.identity);
    }
}
