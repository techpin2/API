using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subs1 : MonoBehaviour
{
    private void Awake()
    {
        CallBackFuncti.action += Disp;
        CallBackFuncti.actionMsg += Disp;
    }

    public void Disp()
    {
        print("subs1");
    }

    public void Disp(string msg)
    {
        print("Hey Susb1 "+msg);
    }

    private void OnDisable()
    {
        CallBackFuncti.action -= Disp;
        CallBackFuncti.actionMsg -= Disp;
    }
}
