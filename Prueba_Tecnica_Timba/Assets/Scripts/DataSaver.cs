using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class DataSaver : MonoBehaviour
{
    private string URL = "http://localhost:3000";

    //public PlayerData[] players;

    [ContextMenu("Test Request Create")]
    public void OnCreatePlayers(string name)
    {
        StartCoroutine(TryCreatePlayer(name));
    }

    [ContextMenu("Test Request Read")]
    public void OnReadPlayers()
    {
        StartCoroutine(TryGetPlayers());
    }

    private IEnumerator TryCreatePlayer(string name)
    {        
        PlayerData player = new PlayerData(name);
        string json = JsonUtility.ToJson(player);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        UnityWebRequest request = UnityWebRequest.Post(URL + "/createPlayer", "POST");
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        var handler = request.SendWebRequest();
        float startTime = 0;
        while (!handler.isDone)
        {
            startTime += Time.deltaTime;
            if (startTime > 10f)
            {
                break;
            }
            yield return null;
        }

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(request.downloadHandler.text);
        }
        else
        {
            Debug.Log("No se pudo crear");
        }
        request.uploadHandler.Dispose();
        request.downloadHandler.Dispose();
        
        yield return null;
    }
    private IEnumerator TryGetPlayers()
    {
        UnityWebRequest request = UnityWebRequest.Get(URL + "/readAll");
        var handler = request.SendWebRequest();

        float startTime = 0f;
        while (!handler.isDone)
        {
            startTime += Time.deltaTime;

            if (startTime > 10f)
            {
                break;
            }

            yield return null;
        }

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(request.downloadHandler.text);
            string json = request.downloadHandler.text;
            string[] jsonObjects = json.Split(new string[] { "}," }, StringSplitOptions.RemoveEmptyEntries);
            PlayerData[] newPlayers;
            newPlayers = JsonUtility.FromJson<PlayerData[]>(json);
            Debug.Log(newPlayers[0].namePlayer);
            //string json = request.downloadHandler.text;
            //List<PlayerData> players = new List<PlayerData>();
            //foreach(string s in jsonObjects)
            //{
            //    Debug.Log(s);
            //}
        }
        else
        {
            Debug.Log("No se pudo leer");
        }
        request.downloadHandler.Dispose();

        yield return null;
    }
}
