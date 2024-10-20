using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
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

    [Header("Cauldron")]
    Cauldron cauldron;

    [Header("Holding Object")]
    [SerializeField]
    [Range(0,5)]

    private int maxStackSize = 5;
    [SerializeField]
    GameObject potionArt;
    // Reference to the game objects that the character carries in the world
    List<GameObject> ingredientArt = new();
    Potion currentPotion;
    

    private GameObject objectCurrentlyOn;

    [Header("Animator")]
    public Animator animator;
    
    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        playerInventory = GetComponent<PlayerInventory>();
        
        playerInput = new();
        playerInput.Controls.SwitchCharacter.performed += OnControlSwitchCharacter;
        playerInput.Controls.Interact.performed += OnInteract;
        playerInput.Controls.Drop.performed += OnDrop;

        switchCharacter = transform.parent.GetComponent<SwitchCharacter>();
    }

    private void Start() {
        for (int i = 0; i < maxStackSize; i++)
        {
            ingredientArt.Add(transform.GetChild(i).gameObject);
        }

    }

    private void OnEnable() {
        playerInput.Enable();
    }

    private void OnDisable() {
        playerInput.Disable();
    }

    private void Update() {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        objectCurrentlyOn = other.gameObject;
    }

    private void OnTriggerStay2D(Collider2D other) {
        objectCurrentlyOn = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other) {
        objectCurrentlyOn = null;
    }

    private void Move()
    {
        moveDir = playerInput.Controls.Move.ReadValue<Vector2>();
        animator.SetFloat("Speed", math.abs(moveDir.x + moveDir.y));

        if (moveDir.x > 0) 
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveDir.x < 0) 
        {
            GetComponent<SpriteRenderer>().flipX = false;
        } else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

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

        // Update Holding Stack
        DropTop();

        // Getting reference to ingredient
        ingr = playerInventory.RemoveItem();
        foreach (var pool in ingredientPools)
        {
            if (pool.objectToCopy == ingr.gameObject) ingrToDropPool = pool;
        }
        if (!ingrToDropPool) throw new Exception(ingr.name + " not in object pool");

        // Dropping ingredient
        ingrToDrop = ingrToDropPool.GetObject();
        Vector3 dropPos = ingredientArt[0].transform.position;
        dropPos.y -= 1.5f;
        ingrToDrop.transform.position = dropPos;
        ingrToDrop.SetActive(true);
    }

    private void OnInteract(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!objectCurrentlyOn) { return;}
        switch (objectCurrentlyOn.tag)
        {
            case "Customer":
                GivePotion();
                break;
            case "Cauldron":
                CollectPotion();
                break;
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
        if (playerInventory.InventoryCount() >= maxStackSize) return;
        Ingredient ingr = objectCurrentlyOn.GetComponent<Barrel>().ingr;
        playerInventory.AddToInventory(ingr);
        ChangeItemArt(ingr.gameObject.transform.GetChild(0).gameObject);
    }

    private void PickUpIngredient() {
        if (playerInventory.InventoryCount() > maxStackSize) return;
        Ingredient ingr = objectCurrentlyOn.transform.parent.GetComponent<IngredientHolder>().ingredient;

        playerInventory.AddToInventory(ingr);
        ChangeItemArt(objectCurrentlyOn);
        objectCurrentlyOn.SetActive(false);
    }

    private void UseCauldron()
    {
        if (!cauldron) { cauldron = objectCurrentlyOn.GetComponent<Cauldron>(); }
        if (playerInventory.InventoryCount() <= 0 || cauldron.IsFull()) { return; }
        DropTop();
        cauldron.AddIngredient(playerInventory.RemoveItem());
    }

    private void CollectPotion() {
        Cauldron caul = objectCurrentlyOn.GetComponent<Cauldron>();
        if (!caul.IsPotionGrabbable) return;
        currentPotion = caul.CollectPotion();
        if (!currentPotion) return;
        potionArt.GetComponent<SpriteRenderer>().sprite = currentPotion.potionObject.GetComponentInChildren<SpriteRenderer>().sprite ;
    }

    private void GivePotion() {
        if (!currentPotion) return;
        objectCurrentlyOn.GetComponent<CustomerOrders>().RecievePotion(currentPotion);

        currentPotion = null;
        potionArt.GetComponent<SpriteRenderer>().sprite = null;
    }

    private void ChangeItemArt(GameObject newItem) {
        int index = math.clamp(playerInventory.InventoryCount()-1,0,maxStackSize);
        if (index >= maxStackSize) { return; }
        ingredientArt[index].GetComponentInChildren<SpriteRenderer>().sprite = newItem.GetComponent<SpriteRenderer>().sprite;
    }

    private void DropTop() {
        int index = playerInventory.InventoryCount()-1;
        if (index < 0) { return; }
        ingredientArt[index].GetComponentInChildren<SpriteRenderer>().sprite = null;
        // ingredientArt[index].gameObject.SetActive(false);// = null;
    }
}
