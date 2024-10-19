using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    float moveForce;
    PlayerInput playerInput;
    Vector2 moveDir = new();
    Rigidbody2D rb2D;

    [Header("Swap Char")]
    SwitchCharacter switchCharacter;

    [Header("Food Interaction")]
    [SerializeField]
    List<ObjectPool> ingredientPools;
    PlayerInventory playerInventory;
    PlayerPickUp playerPickUp;

    [Header("Cauldron")]
    Cauldron cauldron;



    private GameObject objectCurrentlyOn;
    
    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        playerInventory = GetComponent<PlayerInventory>();
        playerPickUp = GetComponent<PlayerPickUp>();
        
        playerInput = new();
        playerInput.Controls.SwitchCharacter.performed += OnControlSwitchCharacter;
        playerInput.Controls.Interact.performed += OnInteract;
        playerInput.Controls.Drop.performed += OnDrop;

        switchCharacter = transform.parent.GetComponent<SwitchCharacter>();
    }

    private void OnEnable() {
        playerInput.Enable();
    }

    private void OnDisable() {
        playerInput.Disable();
    }

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        objectCurrentlyOn = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other) {
        objectCurrentlyOn = null;
    }

    private void Move()
    {
        moveDir = playerInput.Controls.Move.ReadValue<Vector2>();
        // transform.position += moveForce * Time.deltaTime * (Vector3)moveDir;
        rb2D.AddForce(moveForce * moveDir, ForceMode2D.Force);
    }

    private void OnControlSwitchCharacter(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        switchCharacter.ToggleCharacters();
    }

    private void OnDrop(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (objectCurrentlyOn && objectCurrentlyOn.CompareTag("Cauldron")) {
            UseCauldron();
        } else {
            ProcessDrop();
        }
    }

    private void ProcessDrop()
    {
        Ingredient ingr = null;
        GameObject ingrToDrop = null;
        ObjectPool ingrToDropPool = null;
        if (playerInventory.InventoryCount() <= 0) return;

        // Getting referenc to ingredient
        ingr = playerInventory.RemoveItem();
        foreach (var pool in ingredientPools)
        {
            if (pool.objectToCopy == ingr.gameObject) ingrToDropPool = pool;
        }
        if (!ingrToDropPool) throw new Exception(ingr.name + " not in object pool");

        // Dropping ingredient
        ingrToDrop = ingrToDropPool.GetObject();
        ingrToDrop.transform.position = transform.position;
        ingrToDrop.SetActive(true);
    }

    private void OnInteract(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!objectCurrentlyOn) { return;}
        switch (objectCurrentlyOn.tag)
        {
            case "Barrel":
                GetIngredientFromBarrel();
                break;
            case "Ingredient":
                PickUpIngredient();
                break;
            default:
                break;
        }
    }

    private void GetIngredientFromBarrel() {
        playerInventory.AddToInventory(objectCurrentlyOn.GetComponent<Barrel>().ingr);
    }

    private void PickUpIngredient() {
        playerInventory.AddToInventory(objectCurrentlyOn.transform.parent.GetComponent<IngredientHolder>().ingredient);
        objectCurrentlyOn.SetActive(false);
    }

    private void UseCauldron()
    {
        if (!cauldron) { cauldron = objectCurrentlyOn.GetComponent<Cauldron>(); }
        if (playerInventory.InventoryCount() <= 0) { return; }
        cauldron.AddIngredient(playerInventory.RemoveItem());
    }
}
