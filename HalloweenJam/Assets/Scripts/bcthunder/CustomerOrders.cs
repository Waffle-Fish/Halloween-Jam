using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrders : MonoBehaviour
{
    public List<Potion> possiblePotions = new();        // List of possible potions to make (Changed to game object)
    public List<GameObject> possibleOrderDisplay = new();

    public Potion orderedPotion;
    public int orderNumber;
    public GameObject orderDisplay;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        MakeOrder();
    }

    public void MakeOrder()
    {
        orderNumber = Random.Range(0, 5);
        orderedPotion = possiblePotions[orderNumber];
        orderDisplay = Instantiate(possibleOrderDisplay[orderNumber], transform.position, Quaternion.identity, transform);
        orderDisplay.SetActive(false);
        // spriteRenderer = orderDisplay.GetComponent<SpriteRenderer>();
        // spriteRenderer.enabled = !spriteRenderer.enabled;
    }

    public void DisplayOrder()
    {
        Debug.Log("Show the order");
        orderDisplay.transform.position = this.transform.position + new UnityEngine.Vector3(0, -1 , 0);
        orderDisplay.SetActive(true);
        // spriteRenderer.enabled = !spriteRenderer.enabled;

        // Debug.Log("Is order showing: " + spriteRenderer.enabled.ToString());
    }

    public void HideOrder()
    {
        Debug.Log("Hide the order");
        spriteRenderer.enabled = !spriteRenderer.enabled;
    }

}
