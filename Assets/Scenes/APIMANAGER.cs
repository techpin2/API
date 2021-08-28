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

    public string GenrateUrl(string subUrl)
    {
        string completeUrl = "";
        switch(subUrl)
        {
            case "test":
                completeUrl= serverUrl + test;
                break;
            case "login":
                completeUrl = serverUrl + login;
                break;
            case "register":
                completeUrl = serverUrl + register;
                break;
        }
        return completeUrl;
    }

    public void PostData(string url,string data, System.Action<string> callback)
    {
        StartCoroutine(Post(url, data,callback));
    }

    public void GetData(string url)
    {
        StartCoroutine(Get(url));
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

    IEnumerator Get(string url)
    {
        using(UnityWebRequest www=UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isHttpError || www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                
            }
        }
       
    }
}
