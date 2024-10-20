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
}
