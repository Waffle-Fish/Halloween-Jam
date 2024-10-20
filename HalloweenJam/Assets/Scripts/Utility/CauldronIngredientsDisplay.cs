using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronIngredientsDisplay : MonoBehaviour
{
    private GameObject displayBubble;
    private List<GameObject> displayIngr;

    private void Awake() {
        displayBubble = transform.GetChild(0).gameObject;
        foreach (Transform child in displayBubble.transform)
        {
            displayIngr.Add(child.gameObject);
        }
    }


}
