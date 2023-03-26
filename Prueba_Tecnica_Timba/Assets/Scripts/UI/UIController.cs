using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] TMP_InputField nameField;
    [SerializeField] TextMeshProUGUI scoreBoardNames, scoreBoardScores;
    [SerializeField] DataSaver dataSaver;

    private void Awake()
    {
        instance = this;    
    }

    public void OnPlayButton()
    {
        if(nameField.text != null)
        {
            CurrentPlayer.instance.SetNamePlayer(nameField.text);
            //dataSaver.OnCreatePlayers(nameField.text);            
        }
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
        foreach (PlayerData p in dataSaver.players)
        {
            scoreBoardNames.text += p.namePlayer +"\n";
            scoreBoardScores.text += p.scorePlayer + "\n";
        }

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
