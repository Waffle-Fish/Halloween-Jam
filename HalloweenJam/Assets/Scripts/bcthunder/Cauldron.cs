using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    private List<Ingredient> inCauldron;

    public Timer cookingTimer;
    public Timer burningTimer;

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
        if (cookingTimer.IsTimeCountingDown())
        {

        }
    }

    // Check the ingredients in the cauldrons
    void CheckIngredients()
    {
        if (inCauldron.Count >= 3 && inCauldron.Count <= 5)
        {

        }
    }

    // Add an ingredient to the pot
    void AddIngredient(Ingredient ingr)
    {
        inCauldron.Add(ingr);

        cookingTimer.StartCountdown();

        CheckIngredients();
    }

    // Check if ingredient enters pot
    void OnCollisionEnter(Collision collision)
    {
        /*
        foreach (Ingredient ingr in collision)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        if (collision.relativeVelocity.magnitude > 2)
            audioSource.Play();
        */
    }
}
