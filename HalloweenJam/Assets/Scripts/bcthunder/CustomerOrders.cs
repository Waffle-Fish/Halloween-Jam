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

    void start()
    {
        string four = 4
        for (int i =0 i < 8 i++) {
            dostuff;
        }
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
