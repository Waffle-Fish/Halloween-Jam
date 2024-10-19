using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    List<Ingredient> inventory = new();

    public void AddToInventory(Ingredient ing) {
        inventory.Add(ing);
    }

    /// <summary>
    /// Get's rid of the latest item in the inventory
    /// </summary>
    /// <param name="ing"></param>
    public Ingredient RemoveItem() {
        Ingredient ing = inventory[^1];
        inventory.RemoveAt(inventory.Count - 1);
        return ing;
    }

    public int InventoryCount() {
        return inventory.Count;
    }
}
