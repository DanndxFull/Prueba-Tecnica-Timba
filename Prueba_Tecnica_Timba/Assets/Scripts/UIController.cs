using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_InputField nameField;
    [SerializeField] TextMeshProUGUI scoreBoard;
    [SerializeField] DataSaver dataSaver;

    public void OnPlayButton()
    {
        if(nameField.text != null)
        {
            dataSaver.OnCreatePlayers(nameField.text);
            dataSaver.OnReadPlayers();            
        }
    }

    [ContextMenu("Charge Names")]
    public void ChargeNames()
    {
        scoreBoard.text = "";
        foreach (PlayerData p in dataSaver.players)
        {
            scoreBoard.text += p.namePlayer + " - " + p.scorePlayer + "\n";
        }
    }

}
