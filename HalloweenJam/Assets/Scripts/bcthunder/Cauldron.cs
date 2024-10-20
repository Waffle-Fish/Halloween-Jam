using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [Header("Timer")]
    [Tooltip("How long it takes to cook one ingredient")]
    public int cookingTime;

    public float Stopwatch {get; private set;}

    [Header("Potion stuff")]
    [SerializeField]
    private List<Potion> potionList;
    [SerializeField]
    private Potion badPotion;
    public bool IsPotionGrabbable { get; private set; } = false;
    public List<Ingredient> inCauldron = new();
    private int numIngrAdded = 0;

    [SerializeField]
    GameObject doneSparkles;
    [SerializeField]
    GameObject cookSparkles;

    private void Awake() {
        foreach (Potion potion in potionList)
        {
            potion.totalValue = CalculatePotionValue(potion);
        }
    }

    void Update()
    {
        if (inCauldron.Count <= 0) return;

        // Cook pot
        Stopwatch += Time.deltaTime;
        IsPotionGrabbable = Stopwatch >= TotalCookingDuration();
        doneSparkles.SetActive(IsPotionGrabbable);
        cookSparkles.SetActive(!IsPotionGrabbable);
    }

    public void AddIngredient(Ingredient ingr)
    {
        if (IsFull()) return;
        inCauldron.Add(ingr);
        ResetStopwatch();
    }

    public bool IsFull() {
        return inCauldron.Count >= 5;
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

    public float TotalCookingDuration() {
        return cookingTime * inCauldron.Count;
    }

    void ClearCauldron()
    {
        inCauldron.Clear();
        ResetStopwatch();
    }

    private void ResetStopwatch() {
        Stopwatch = 0f;
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
