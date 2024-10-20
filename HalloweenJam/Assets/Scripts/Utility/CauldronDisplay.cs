using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronDisplay : MonoBehaviour
{
    public float Duration {get; private set;}
    Transform bar;

    private Cauldron cauldron;

    float finalXScale;

    Vector3 barPos;
    Vector3 barScale;

    private void Awake() {
        cauldron = transform.parent.GetComponent<Cauldron>();
        bar = transform.GetChild(0).GetChild(0);
        barPos = bar.localPosition;
        barScale = bar.localScale;
        finalXScale = barScale.x;
    }

    private void OnEnable() {
        ResetBar();
    }

    private void Start() {
        gameObject.SetActive(false);
    }

    private void Update() {
        UpdateBar();
    }

    public void UpdateBar() {
        if (barScale.x >= finalXScale) return;
        float delta = Time.deltaTime * finalXScale / Duration;
        barScale.x += delta;
        barPos.x -= delta / 2f;

        bar.localScale = barScale;
        bar.localPosition = barPos;
    }

    public void SetDuration(float newDuration) {
        Duration = newDuration;
    }

    private void ResetBar()
    {
        barScale.x = 0f;
        bar.localScale = barScale;

        barPos.x = finalXScale / 2f;
        bar.localPosition = -barPos;
    }

    public void ReCenterBar(int numIngrAdded) {
        float percentComplete = bar.localScale.x / finalXScale;
        float sectionLength = finalXScale / numIngrAdded;
        barScale.x = sectionLength * percentComplete;
        bar.localScale = barScale;

        barPos.x = bar.localScale.x * 2f;
        bar.localPosition = -barPos;
    }
}
