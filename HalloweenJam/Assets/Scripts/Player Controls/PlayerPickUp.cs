using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInventory))]
public class PlayerPickUp : MonoBehaviour
{
    PlayerInventory playerInventory;

    private void Awake() {
        playerInventory = GetComponent<PlayerInventory>();
    }
}
