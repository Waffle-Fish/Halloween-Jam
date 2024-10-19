using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerBehavior : MonoBehaviour
{
    public Sprite customerSprite;

    public bool isReadyToOrder = true;

    CustomerOrders order = new CustomerOrders();


    // Start is called before the first frame update
    void Start()
    {
        order = order.MakeOrder();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReadyToOrder)
        {
            ReadyToOrder();
            isReadyToOrder = false;
        }
    }

    void DisplayOrder()
    {
        order.DisplayOrder();
    }
}
