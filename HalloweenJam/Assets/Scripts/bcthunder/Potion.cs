using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "ScriptableObject/Potions")]
public class Potion : ScriptableObject
{
    public string potionName;
    public List<Ingredient> ingredients;
    public GameObject orderDisplay;

    [Tooltip("Don't initialize this, it will get overwritten")]
    public int totalValue;

    public GameObject potionObject;
}
