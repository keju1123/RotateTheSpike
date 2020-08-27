using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    public static int score = 0;

    void Start()
    {
        
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }
}
