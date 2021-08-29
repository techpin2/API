using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class APIMANAGER : MonoBehaviour
{
    public string serverUrl = "http://192.168.43.80:4004/admin";
    public string test = "/test";
    public string getUsers = "/getusers";
    public string login = "/login";
    public string register = "/register";

    public static APIMANAGER apiManager;

    private void Awake()
    {
        apiManager = this;
    }

    private string GenrateUrl(RequestType type)
    {
        string completeUrl = "";
        switch(type)
        {
            case RequestType.Test:
                completeUrl= serverUrl + test;
                break;
            case RequestType.Login:
                completeUrl = serverUrl + login;
                break;
            case RequestType.Register:
                completeUrl = serverUrl + register;
                break;
        }
        return completeUrl;
    }

    public void PostData(RequestType type,string data, System.Action<string> callback)
    {
        string url = GenrateUrl(type);
        StartCoroutine(Post(url, data,callback));
    }

    IEnumerator Post(string url, string data, System.Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(url, data))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(data);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.isHttpError || www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                callback?.Invoke(www.downloadHandler.text);
            }
        }
    }
}

public enum RequestType
{
    Test,
    Login,
    Register
}
