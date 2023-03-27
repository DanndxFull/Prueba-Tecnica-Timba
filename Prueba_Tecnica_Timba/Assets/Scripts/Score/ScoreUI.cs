using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText, nameText;

    private void Start()
    {        
        string name = CurrentPlayer.instance.GetNamePlayer();
        nameText.text = "Player: " + name;
    }

    private void Update()
    {
        scoreText.text = "Score: " + ScoreTime.currentScore;
    }
}
