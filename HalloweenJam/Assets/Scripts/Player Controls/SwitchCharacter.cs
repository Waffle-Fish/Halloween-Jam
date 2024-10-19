using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    [SerializeField]
    PlayerControls witch;
    [SerializeField]
    PlayerControls broom;

    [SerializeField]
    GameObject witchCam;
    [SerializeField]
    GameObject broomCam;

    private void Awake() {
        witchCam.SetActive(true);
        broomCam.SetActive(false);
        witch.enabled = true;
        broom.enabled = false;   
    }

    public void ToggleCharacters() {
        witch.enabled = !witch.enabled;
        broom.enabled = !broom.enabled;

        witchCam.SetActive(!witchCam.activeSelf);
        broomCam.SetActive(!broomCam.activeSelf);
    }
}
