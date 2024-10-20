using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CustomerBehavior : MonoBehaviour
{
    [SerializeField] Transform[] walkPoints;
    [SerializeField] private float moveSpeed;
    private int walkPointIndex = 0;

    public Sprite customerSprite;

    private bool isReadyToOrder = true;

    public CustomerOrders order;

    void Awake() {
        order = GetComponent<CustomerOrders>();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = walkPoints[walkPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, walkPoints[walkPointIndex+1].transform.position, moveSpeed * Time.deltaTime);

        if (transform.position == walkPoints[1].position) {
            DisplayOrder();
        }
        
    }

    void DisplayOrder()
    {
        order.DisplayOrder();
    }
}
