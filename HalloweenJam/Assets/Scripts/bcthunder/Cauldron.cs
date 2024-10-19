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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cookingTimer.CheckTimerFinished() && !burningTimer.IsTimeCountingDown())
        {
            burningTimer.StartCountdown();
        } else if (burningTimer.CheckTimerFinished()) { isPotionBurnt = true; }
    }

    // Check the ingredients in the cauldrons
    void CheckIngredients()
    {
        if (inCauldron.Count >= 3 && inCauldron.Count <= 5)
        {
            isPotionGrabbable = true;
        }
    }

    // Add an ingredient to the pot
    void AddIngredient(Ingredient ingr)
    {
        if (inCauldron.Count <= 5)
        {
            inCauldron.Add(ingr);

            // If the Player adds an additional ingredient, reseting the cooking timer 
            if (cookingTimer.IsTimeCountingDown())
            {
                cookingTimer.ResetTimer();
            
            // If the Player adds an ingredient for the first time, 
            }
            else
            {
                cookingTimer.StartCountdown();
            }
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
