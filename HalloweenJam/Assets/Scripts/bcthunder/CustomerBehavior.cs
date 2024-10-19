using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerBehavior : MonoBehaviour
{
    public Sprite customerSprite;

    public bool isReadyToOrder = true;

    public class CustomerOrders : MonoBehaviour
    {
        public List<Potion> possiblePotions;
        public List<GameObject> possibleOrderDisplay;

        public Potion orderedPotion;
        public int orderNumber;
        public GameObject orderDisplay;

        public bool showOrderDisplay = false;

        void start()
        {
            
        }

        public void MakeOrder()
        {
            orderNumber = Random.Range(0, 6);
            orderedPotion = possiblePotions[orderNumber];
            orderDisplay = possibleOrderDisplay[orderNumber];
        }

        public void DisplayOrder()
        {
            showOrderDisplay = true;
        }

    }

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
