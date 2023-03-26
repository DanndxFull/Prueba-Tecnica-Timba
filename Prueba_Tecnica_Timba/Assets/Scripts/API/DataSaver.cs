using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
public class DataSaver : MonoBehaviour
{
    private string URL = "http://localhost:3000";

    public List<PlayerData> players;

    public void OnCreatePlayers(string name,int score)
    {
        StartCoroutine(TryCreatePlayer(name,score));
    }

    public void OnReadPlayers()
    {
        StartCoroutine(TryGetPlayers());
    }

    private IEnumerator TryCreatePlayer(string name,int score)
    {        
        PlayerData player = new PlayerData(name,score);
        string json = JsonUtility.ToJson(player);
        Debug.Log(json);

        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        using (UnityWebRequest request = UnityWebRequest.Post(URL + "/createPlayer", string.Empty))
        {
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            var operation = request.SendWebRequest();

            float startTime = 0f;
            while (!operation.isDone)
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
        }
        yield return null;
    }
    private IEnumerator TryGetPlayers()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL + "/readAll"))
        {
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

                players = JsonConvert.DeserializeObject<List<PlayerData>>(request.downloadHandler.text);
                foreach (PlayerData p in players)
                {
                    Debug.Log("Nombre:" + p.namePlayer + " Score:" + p.scorePlayer);
                }
                UIController.instance.ChangeNames();
            }
            else
            {
                Debug.Log("No se pudo leer");
            }
        }
        yield return null;
    }
}
