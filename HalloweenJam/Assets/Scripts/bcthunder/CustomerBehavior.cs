using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CustomerBehavior : MonoBehaviour
{
    public CustomerOrders order;

    void Awake() {
        order = GetComponent<CustomerOrders>();
    }

    // Start is called before the first frame update
    void Start()
    {
        order.transform.position = transform.position + new UnityEngine.Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
