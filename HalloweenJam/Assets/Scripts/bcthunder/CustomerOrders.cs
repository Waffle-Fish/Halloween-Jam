using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrders : MonoBehaviour
{
    public List<Potion> possiblePotions;
    public List<GameObject> possibleOrderDisplay;

    public Potion orderedPotion;
    public int orderNumber;
    public GameObject orderDisplay;

    public bool showOrderDisplay = false;

    void MakeOrder()
    {
        orderNumber = Random.Range(0, 6);
        orderedPotion = possiblePotions[orderNumber];
        orderDisplay = possibleOrderDisplay[orderNumber];
        showOrderDisplay = true;
    }

}
