using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrders : MonoBehaviour
{
    public Dictionary<string, List<Ingredient>> recipe_book = new Dictionary<string, List<Ingredient>>
    {
        { "LovePotion", ['MidnightOrchid', 'FishTears', 'EyeOfNewt']},
        { "HairGrowth", ['MidtermExam', 'MidtermExam', 'CandyStolenFromChild'] },
        { "Poison", ["MidtermExam", "FishTears"] },
        { "Health", ["MidnightOrchid", "EyeOfNewt"] },
        { "" }
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
