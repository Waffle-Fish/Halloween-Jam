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
    private List<Ingredient> inCauldron = new();

    private void Awake() {
        foreach (Potion potion in potionList)
        {
            potion.totalValue = CalculatePotionValue(potion);
        }
    }

    private void Start() {
        cookDisplay.SetDuration(cookingTime);
        burnDisplay.SetDuration(burnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (inCauldron.Count <= 0) return;

        // Cook pot
        if (!cookDisplay.gameObject.activeInHierarchy) cookDisplay.gameObject.SetActive(true);
        Stopwatch += Time.deltaTime;
        IsPotionGrabbable = Stopwatch >= cookingTime * inCauldron.Count;

        // Burn Pot
        // if (IsPotionGrabbable & !burnDisplay.gameObject.activeInHierarchy) {
        //     burnDisplay.gameObject.SetActive(true);
        // }
        if (Stopwatch >= cookingTime * inCauldron.Count + burnTime) {
            ClearCauldron();
        }
    }

    // Add an ingredient to the pot
    public void AddIngredient(Ingredient ingr)
    {
        if (IsFull())
        {
            inCauldron.Add(ingr);
            cookDisplay.SetDuration(cookDisplay.Duration + cookingTime);
            burnDisplay.gameObject.SetActive(false);
            // ResetStopwatch();
        }
    }

    public bool IsFull() {
        return inCauldron.Count < 5;
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
