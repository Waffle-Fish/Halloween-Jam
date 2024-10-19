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
    
    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        
        playerInput = new();
        playerInput.Controls.SwitchCharacter.performed += OnControlSwitchCharacter;

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
}
