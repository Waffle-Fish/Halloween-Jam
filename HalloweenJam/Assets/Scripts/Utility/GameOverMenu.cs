using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + GameManager.Instance.totalPoints.ToString();
    }
}
