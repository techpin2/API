using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subs2 : MonoBehaviour
{
    private void Awake()
    {
        CallBackFuncti.action += Disp;
        CallBackFuncti.actionMsg += Disp;
    }

    public void Disp()
    {
        print("subs2");
    }

    public void Disp(string msg)
    {
        print("Hey Susb2 " + msg);
    }

    private void OnDisable()
    {
        CallBackFuncti.action -= Disp;
        CallBackFuncti.actionMsg -= Disp;
    }
}
