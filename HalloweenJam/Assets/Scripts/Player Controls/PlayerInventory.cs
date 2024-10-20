using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    Stack<Ingredient> inventory = new();

    public void AddToInventory(Ingredient ing) {
        inventory.Push(ing);
    }

    /// <summary>
    /// Get's rid of the latest item in the inventory
    /// </summary>
    /// <param name="ing"></param>
    public Ingredient RemoveItem() {
        return inventory.Pop();
    }

    public int InventoryCount() {
        // Debug.Log(inventory.Count);
        return inventory.Count;
    }
}
