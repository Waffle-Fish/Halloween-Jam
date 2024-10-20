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
    private float stopwatch;

    [Header("Potion stuff")]
    [SerializeField]
    private List<Potion> potionList;
    [SerializeField]
    private Potion badPotion;
    public bool IsPotionGrabbable { get; private set; } = false;
    private List<Ingredient> inCauldron = new();

    private void Awake() {
        foreach (Potion potion in potionList)
        {
            potion.totalValue = CalculatePotionValue(potion);
        }
    }

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

    public Potion CollectPotion()
    {
        if (inCauldron.Count <= 0) { return null;}
        int value = 0;
        foreach (Ingredient ingr in inCauldron)
        {
            value += ingr.value;
        }
        Potion foundPotion = potionList.Find(x => x.totalValue == value);
        if (foundPotion == null) { foundPotion = badPotion;}
        ClearCauldron();
        return foundPotion;
    }

    private int CalculatePotionValue(Potion p) {
        int value = 0;
        foreach (var ingr in p.ingredients)
        {
            value += ingr.value;
        }
        return value;
    }
}
