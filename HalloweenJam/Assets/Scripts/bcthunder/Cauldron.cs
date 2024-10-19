using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    private List<Ingredient> inCauldron;

    // public Player player;        // player reference

    public Timer cookingTimer;
    public Timer burningTimer;

    public bool isPotionBurnt = false;
    public bool isPotionGrabbable = false;

    private void Awake()
    {
        cookingTimer = GetComponents<Timer>()[0];
        burningTimer = GetComponents<Timer>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        // When the potion cooking timer is finished, start the burning timer
        if (cookingTimer.CheckTimerFinished() && !burningTimer.IsTimerCountingDown())
        {
            burningTimer.StartCountdown();
        } else if (burningTimer.CheckTimerFinished()) {
            ClearCauldron();
        }
    }

    // 
    void ClearCauldron()
    {
        inCauldron.Clear();
        cookingTimer.ResetTimer();
        burningTimer.ResetTimer();
    }

    // Check the ingredients in the cauldrons
    void CheckIngredients()
    {
        if (!cookingTimer.IsTimerCountingDown() && inCauldron.Count >= 1)
        {
            isPotionGrabbable = true;
        }
    }

    // Add an ingredient to the pot
    public void AddIngredient(Ingredient ingr)
    {
        if (inCauldron.Count <= 5)
        {
            inCauldron.Add(ingr);
            cookingTimer.ResetTimer();
        }

        CheckIngredients();
    }

    // Check if ingredient enters pot
    void OnCollisionEnter(Collision collision)
    {
        /*
        if the collision is the player and the potion is grabbable
        if grabbed
            isPotionGrabbable = false;
            inCauldron.clear();

        if addIngredient
            AddIngredient(the ingredient);
        */
    }
}
