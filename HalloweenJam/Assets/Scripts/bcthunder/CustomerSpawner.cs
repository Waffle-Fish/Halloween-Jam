using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] public GameObject customerPrefab;

    public GameObject customer;

    void Start()
    {
        
    }

    public void SpawnCustomer()
    {
        customer = Instantiate(customerPrefab, transform.position, Quaternion.identity);
    }

    public GameObject GetCustomer(){
        if (customer != null) {
            return customer;
        } else {
            return null;
        }
    }
}
