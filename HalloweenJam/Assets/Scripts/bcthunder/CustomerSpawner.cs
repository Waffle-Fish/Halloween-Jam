using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] public GameObject customerPrefab;

    [SerializeField] public Transform[] walkPoints;

    [SerializeField] public int moveSpeed = 10;

    String[] meows = {"meow1", "meow2", "meow3"};

    Transform targetWalkPoint;

    GameObject customer;
    Animator customerAnimator;
    CustomerBehavior customer_script;
    CustomerOrders order;
    bool showOrder = true;
    bool leaveBar = false;


    void Start()
    {
        targetWalkPoint = walkPoints[1];        // the initial walk point is the counter
    }

    void Update(){
        if (customer != null) {
            customerAnimator.SetBool("walkDown", false);
            customer.transform.position = Vector2.MoveTowards(customer.transform.position, targetWalkPoint.transform.position, moveSpeed * Time.deltaTime);

            if (showOrder && customer.transform.position == walkPoints[1].transform.position) {
                order.DisplayOrder();
                // AudioManager.Instance.PlaySFX(meows[UnityEngine.Random.Range(0,2)]);
                showOrder = false;
            }

            if (leaveBar) {
                customerAnimator.SetBool("walkDown", true);
                customer.transform.position = Vector2.MoveTowards(customer.transform.position, targetWalkPoint.transform.position, moveSpeed * Time.deltaTime);
                // AudioManager.Instance.PlaySFX(meows[UnityEngine.Random.Range(0,2)]);

                if (customer.transform.position == walkPoints[0].transform.position) {
                    Debug.Log("Customer has succesfully been remove");
                    Destroy(customer);
                    customer = null;
                    targetWalkPoint = walkPoints[1];
                }
            }
        }
    }

    public void SpawnCustomer()
    {
        customer = Instantiate(customerPrefab, transform.position, Quaternion.identity);
        customer.transform.position = walkPoints[0].transform.position;
        customerAnimator = customer.GetComponent<Animator>();
        customer_script = customer.GetComponent<CustomerBehavior>();
        order = customer.GetComponent<CustomerOrders>();
        leaveBar = false;
        Debug.Log("Customer Spawned!");
    }

    public GameObject GetCustomer(){
        if (customer != null) {
            return customer;
        } else {
            return null;
        }
    }

    public void RemoveCustomer() {
        Debug.Log("Remove the customer");
        targetWalkPoint = walkPoints[0];
        leaveBar = true;
        showOrder = true;
    }

}
