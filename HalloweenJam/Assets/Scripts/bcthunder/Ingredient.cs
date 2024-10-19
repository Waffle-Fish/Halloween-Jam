using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "ScriptableObjects/Ingredients", order = 1)]
public class Ingredient : ScriptableObject
{
    public string ingredient_name;
    public Sprite ingredient_sprite;

    
}
