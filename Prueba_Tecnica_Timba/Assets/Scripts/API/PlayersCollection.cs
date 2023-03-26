using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayersCollection
{
    List<PlayerData> players;

    public PlayersCollection()
    {
        players = new List<PlayerData>();
    }
}
