using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;   
    [SerializeField] GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        // scoreText = scoreText + gm.totalScore.toString();
    }
}
