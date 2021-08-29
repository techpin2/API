using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Login : MonoBehaviour
{
    public TMP_InputField emailId;
    public TMP_InputField password;

    public void OnLoginButtonClick()
    {
        string url = APIMANAGER.apiManager.GenrateUrl("login");
        LoginData lData = new LoginData();
        lData.email = emailId.text;
        lData.password = password.text;

       string jsonData= JsonUtility.ToJson(lData);
        print(jsonData);

        APIMANAGER.apiManager.PostData(url, jsonData,LogincallBack);
        //APIMANAGER.apiManager.PostData(url, jsonData,(data)=> { 
        
        
        //});
    }

    private void LogincallBack(string data)
    {
        print(data);
        LoginRes res = JsonUtility.FromJson<LoginRes>(data);
        if(res.message== "success")
        {
            //home page
            Menuui.menuui.SwitchScreen("home");
            HomePage.homepage.transform.GetChild(1).GetComponent<TMP_Text>().text = res.LoginResponse.NAME;
            HomePage.homepage.transform.GetChild(2).GetComponent<TMP_Text>().text = res.LoginResponse.EMAIL;
            HomePage.homepage.transform.GetChild(3).GetComponent<TMP_Text>().text = res.LoginResponse.PASSWORD;

        }
        else
        {
           Menuui.menuui.ShowError("invalid Email or Password");
        }
    }


    public void OnRegisterButtonClick()
    {
        Menuui.menuui.SwitchScreen("register");
    }
}

[System.Serializable]
public class LoginData
{
    public string email;
    public string password;
}

[System.Serializable]
public class LoginResponse
{
    public int ID;
    public string NAME;
    public string EMAIL;
    public string PASSWORD;
    public string PIC;
}

[System.Serializable]
public class LoginRes:Message
{
    public LoginResponse LoginResponse;
}

public class Message
{
    public string message;
}
