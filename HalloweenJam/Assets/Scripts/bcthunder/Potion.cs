using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "ScriptableObject/Potions")]
public class Potion : ScriptableObject
{
    public string potionName;
    public List<Ingredient> ingredients;
    public GameObject orderDisplay;
    
}
