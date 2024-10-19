using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    [SerializeField]
    GameObject witch;
    [SerializeField]
    GameObject broom;

    private void Awake() {
        witch.SetActive(true);    
        broom.SetActive(false);   
    }

    public void ToggleCharacters() {
        witch.SetActive(!witch.activeSelf);
        broom.SetActive(!broom.activeSelf);
    }
}
