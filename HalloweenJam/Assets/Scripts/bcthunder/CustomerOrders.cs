using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrders : MonoBehaviour
{
    public List<Potion> possiblePotions;        // List of possible potions to make (Changed to game object)
    public List<GameObject> possibleOrderDisplay;

    public Potion orderedPotion;
    public int orderNumber;
    public GameObject orderDisplay;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        MakeOrder();
    }

    public void MakeOrder()
    {
        orderNumber = Random.Range(0, 6);
        orderedPotion = possiblePotions[orderNumber];
        orderDisplay = possibleOrderDisplay[orderNumber];
    }

    public void DisplayOrder()
    {
        spriteRenderer.enabled = true;
    }

}
