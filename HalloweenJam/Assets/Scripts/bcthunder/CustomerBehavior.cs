using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CustomerBehavior : MonoBehaviour
{
    public CustomerOrders order;
    public Animator animator;

    bool isPlayerInCollision = false;

    void Awake() {
        order = GetComponent<CustomerOrders>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        order.transform.position = transform.position + new UnityEngine.Vector3(0, -1, 0);
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Witch")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("You can give potion");
        }
    }
}
