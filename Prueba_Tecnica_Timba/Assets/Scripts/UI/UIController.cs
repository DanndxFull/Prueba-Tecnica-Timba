using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private TextMeshProUGUI scoreBoardNames, scoreBoardScores;
    [SerializeField] private DataSaver dataSaver;
    [SerializeField] private SceneLoader sceneLoader;

    private void Awake()
    {
        instance = this;    
    }

    public void OnPlayButton()
    {
        if (nameField.text == null || nameField.text == "")
            return;
        
        CurrentPlayer.instance.SetNamePlayer(nameField.text);
        sceneLoader.ChargeScene("GameScene");        
    }

    [ContextMenu("Charge Names")]
    public void ChargeNames()
    {
        dataSaver.OnReadPlayers();            
    }

    [ContextMenu("Change Names")]
    public void ChangeNames()
    {
        scoreBoardNames.text = "";
        scoreBoardScores.text = "";
        if (dataSaver.players.Count != 0)
        {
            foreach (PlayerData p in dataSaver.players)
            {
                scoreBoardNames.text += p.namePlayer +"\n";
                scoreBoardScores.text += p.scorePlayer + "\n";
            }
        }
        else
        {
            scoreBoardNames.text = "Currently there are not players";
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
