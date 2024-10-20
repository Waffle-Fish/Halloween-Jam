using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HoverOverText : MonoBehaviour
{
    GameObject textBox;
    BoxCollider2D bc2d;

    private void Awake() {
        bc2d = GetComponent<BoxCollider2D>();
        textBox = transform.GetChild(0).gameObject;
        textBox.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        textBox.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D other) {
        textBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        textBox.SetActive(false);
    }
}
