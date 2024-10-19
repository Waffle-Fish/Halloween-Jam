using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    private List<Ingredient> inCauldron;

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
        inCauldron.Add(ingr);

        if (cookingTimer.IsTimeCountingDown())
        {
            cookingTimer.ResetTimer();
        } else
        {
            cookingTimer.StartCountdown();
        }

        CheckIngredients();
    }

    // Check if ingredient enters pot
    void OnCollisionEnter(Collision collision)
    {
        
        
    }
}
