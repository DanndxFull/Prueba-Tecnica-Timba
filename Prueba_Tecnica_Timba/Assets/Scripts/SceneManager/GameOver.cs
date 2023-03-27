using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;

    [SerializeField] private DataSaver dataSaver;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private GameObject GameOverScreen, scoreUI;

    [SerializeField] private TextMeshProUGUI nameText, scoreText;

    private void Awake()
    {
        Time.timeScale = 1;
        instance = this;
    }
    public void GameOverEvent()
    {
        dataSaver.OnCreatePlayers(CurrentPlayer.instance.GetNamePlayer(), ScoreTime.currentScore);
        scoreUI.SetActive(false);
        GameOverScreen.SetActive(true);
        nameText.text = "Player: " + CurrentPlayer.instance.GetNamePlayer();
        scoreText.text = "Score: " + ScoreTime.currentScore.ToString();
        Time.timeScale = 0;
    }
}
