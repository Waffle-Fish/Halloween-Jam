using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField]
    [Tooltip("How long it takes to cook one ingredient")]
    private int cookingTime;
    [SerializeField]
    [Tooltip("How long it takes to burn the whole pot")]
    private int burnTime;

    private List<Ingredient> inCauldron = new();
    private float stopwatch;
    public bool IsPotionGrabbable { get; private set; } = false;

    // Update is called once per frame
    void Update()
    {
        if (inCauldron.Count <= 0) return;
        stopwatch += Time.deltaTime;
        IsPotionGrabbable = stopwatch >= cookingTime * inCauldron.Count;
        if (stopwatch >= cookingTime * inCauldron.Count + burnTime) {
            ClearCauldron();
        }
    }

    void ClearCauldron()
    {
        inCauldron.Clear();
        ResetStopwatch();
    }

    private void ResetStopwatch() {
        stopwatch = 0f;
    }

    // Add an ingredient to the pot
    public void AddIngredient(Ingredient ingr)
    {
        if (inCauldron.Count <= 5)
        {
            inCauldron.Add(ingr);
            ResetStopwatch();
        }
    }
}
