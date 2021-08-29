using UnityEngine;
using System.Collections;
using TMPro;

public class Menuui : MonoBehaviour
{
    public static Menuui menuui;

    private void Awake()
    {
        menuui = this;
    }

    public GameObject registerPanel;
    public GameObject loginPanel;
    public GameObject homePanel;
    public GameObject errorPanel;

    public void SwitchScreen(string name)
    {
        DisableAll();
        
        switch (name)
        {
            case "register":
                registerPanel.SetActive(true);
                break;
            case "login":
                loginPanel.SetActive(true);
                break;
            case "home":
                homePanel.SetActive(true);
                break;
            default:
                print("Invalid Panel");
                break;
        }
       
    }

    public void ShowError(string message)
    {
        errorPanel.transform.GetChild(0).GetComponentInChildren<TMPro.TMP_Text>().text = message;
        errorPanel.SetActive(true);
        StartCoroutine(WaiForSec(2f,()=> 
        {
            errorPanel.SetActive(false);   
        }));
    }

    IEnumerator WaiForSec(float time,System.Action action)
    {
        yield return new WaitForSeconds(time);
        action?.Invoke();
    }
   

    private void DisableAll()
    {
        registerPanel.SetActive(false);
        loginPanel.SetActive(false);
        homePanel.SetActive(false);
    }
    private void Home()
    {

    }
}
