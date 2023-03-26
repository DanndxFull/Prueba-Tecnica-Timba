using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;

    [SerializeField] private DataSaver dataSaver;
    [SerializeField] private SceneLoader sceneLoader;

    private void Awake()
    {
        instance = this;
    }
    public void GameOverEvent()
    {
        dataSaver.OnCreatePlayers(CurrentPlayer.instance.GetNamePlayer(), ScoreTime.currentScore);
        sceneLoader.ChargeScene("MainMenu");
    }
}
