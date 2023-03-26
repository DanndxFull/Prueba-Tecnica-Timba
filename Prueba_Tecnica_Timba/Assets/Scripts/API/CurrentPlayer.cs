using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayer : MonoBehaviour
{
    public static CurrentPlayer instance;
    [SerializeField] private PlayerData player = new PlayerData();

    private void Awake()
    {
        if ( instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public string GetNamePlayer()
    {
        return player.namePlayer;
    }

    public void SetNamePlayer(string name)
    {
        player.namePlayer = name;
    }

    public void SetScorePlayer(int score)
    {
        player.scorePlayer = score;
    }
}
