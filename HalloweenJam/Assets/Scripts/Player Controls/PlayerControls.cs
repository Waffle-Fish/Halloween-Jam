using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    PlayerInput playerInput = new();
    Vector2 moveDir = new();
    
    private void Update() {
        moveDir = playerInput.Controls.Movement.ReadValue<Vector2>();
        Vector3 moveDelta = moveDir * moveSpeed;
        transform.position += moveDelta;
    }
}
