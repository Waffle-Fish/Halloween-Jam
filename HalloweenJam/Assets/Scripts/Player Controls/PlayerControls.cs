using System;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    float moveForce;
    PlayerInput playerInput;
    Vector2 moveDir = new();
    Rigidbody2D rb2D;
    SwitchCharacter switchCharacter;

    private string objectCurrentlyOn;
    
    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        
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
        objectCurrentlyOn = other.tag;
    }

    private void OnTriggerExit2D(Collider2D other) {
        objectCurrentlyOn = "none";
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
        Debug.Log("I dropped ingredients");
    }

    private void OnInteract(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        switch (objectCurrentlyOn)
        {
            case "Cauldron":
                //Use cauldron
                break;
            case "Barrel":
                Debug.Log("I'm using the barrel");
                // Use Barrel
                break;
            default:
                break;
        }
    }
}
