﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Register : MonoBehaviour
{
    public TMP_InputField name;
    public TMP_InputField emailId;
    public TMP_InputField password;

    public void OnRegisterClick()
    {
        RegisterData data = new RegisterData();
        data.name = name.text;
        data.email = emailId.text;
        data.password = password.text;
        string jsonData = JsonUtility.ToJson(data);
        print(jsonData);
        APIMANAGER.apiManager.PostData(RequestType.Register, jsonData, OnRegisterResponse);
    }

    private void OnRegisterResponse(string data)
    {
        Message m = JsonUtility.FromJson<Message>(data);
        if(m.message=="success")
        {
            MenuUI.menuUi.SwitchScreen("login");
        }
        else
        {
            MenuUI.menuUi.ShowError("Something Wrong !!");
        }
    }

}

[System.Serializable]
public class RegisterData
{
    public string name;
    public string email;
    public string password;
}
