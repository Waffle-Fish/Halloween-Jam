using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [Header("Timer")]
    [Tooltip("How long it takes to cook one ingredient")]
    public int cookingTime;
    [Tooltip("How long it takes to burn the whole pot")]
    public int burnTime;
    [SerializeField]
    CauldronDisplay cookDisplay;
    [SerializeField]
    CauldronDisplay burnDisplay;

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

    private void Awake() {
        foreach (Potion potion in potionList)
        {
            potion.totalValue = CalculatePotionValue(potion);
        }
    }

    private void Start() {
        burnDisplay.SetDuration(burnTime);
    }

    void Update()
    {
        if (inCauldron.Count <= 0) return;

        // Cook pot
        if (!cookDisplay.gameObject.activeInHierarchy) cookDisplay.gameObject.SetActive(true);
        Stopwatch += Time.deltaTime;
        IsPotionGrabbable = Stopwatch >= TotalCookingDuration();

        // Burn Pot
        if (IsPotionGrabbable) {
            cookDisplay.gameObject.SetActive(false);
            if (!burnDisplay.gameObject.activeInHierarchy) {
                burnDisplay.gameObject.SetActive(true);
            }
        }
        if (Stopwatch >= TotalCookingDuration() + burnTime) {
            ClearCauldron();
        }
    }

    // Add an ingredient to the pot

    // Old way
    // public void AddIngredient(Ingredient ingr)
    // {
    //     if (IsFull()) return;
    //     inCauldron.Add(ingr);
    //     numIngrAdded++;
    //     if (!cookDisplay.gameObject.activeInHierarchy) cookDisplay.gameObject.SetActive(true);
    //     if (burnDisplay.gameObject.activeInHierarchy) {
    //         burnDisplay.gameObject.SetActive(false);
    //         Stopwatch = TotalCookingDuration() - cookingTime;
    //         cookDisplay.SetDuration(cookingTime);
    //         numIngrAdded = 1;
    //     } else {
    //         cookDisplay.SetDuration(TotalCookingDuration());
    //         cookDisplay.ReCenterBar(numIngrAdded);
    //     }
    // }

    public void AddIngredient(Ingredient ingr)
    {
        if (IsFull()) return;
        inCauldron.Add(ingr);
        if (!cookDisplay.gameObject.activeInHierarchy) cookDisplay.gameObject.SetActive(true);

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
        cookDisplay.gameObject.SetActive(false);
        burnDisplay.gameObject.SetActive(false);
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
