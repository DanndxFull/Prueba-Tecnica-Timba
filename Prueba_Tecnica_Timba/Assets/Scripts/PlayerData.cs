[System.Serializable]
public class PlayerData
{
    public string namePlayer;
    public int scorePlayer;

    public PlayerData()
    {
        namePlayer = "";
        scorePlayer = 0;
    }
    public PlayerData(string name, int score)
    {
        this.namePlayer = name;
        this.scorePlayer = score;
    }
    public PlayerData(string name)
    {
        this.namePlayer = name;
        this.scorePlayer = 0;
    }
}
