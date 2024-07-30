using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SendData : MonoBehaviour

{
    public bool enviarDados = false;
    public int contador = 0;

    IEnumerator SendDataToFlask()
    {
        string url = "http://localhost:5000/data";
        string json = "{\"key\":\"value\"}";  // Dados no formato JSON

        UnityWebRequest www = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        www.uploadHandler = new UploadHandlerRaw(jsonToSend);
        www.downloadHandler = new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Erro: " + www.error);
        }
        else
        {
            Debug.Log("Dados enviados com sucesso!");
        }
    }

    void Start(){

            if(enviarDados){
            StartCoroutine(SendDataToFlask());
            contador++;
            if(contador >= 20){
                contador = 0;
                enviarDados = false;
            }
        }
    }

    void Update()
    {

    }

    public void EnviarDados(){
        StartCoroutine(SendDataToFlask());
    }
}
