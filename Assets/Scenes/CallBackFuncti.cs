using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallBackFuncti : MonoBehaviour
{
    public static System.Action action;
    public static System.Action<string> actionMsg;

    public Image fillImage;
    public Image fillImage1;
    public Image fillImage2;

    public void Start()
    {
        action?.Invoke();
        actionMsg?.Invoke("Video Has Uploaded");

        //if (actionMsg != null)
        //    actionMsg("Video Has uploaded");
        //else
        //    print("No subscriber");

        //StartCoroutine(FillImage(Fill,Complete));

        StartCoroutine(FillImage((value)=>
        {
            fillImage.fillAmount = value;
        },
        ()=>
        {
            print("1st Has Stopped");
            StartCoroutine(FillImage((value) =>
            {
                fillImage1.fillAmount = value;
            },
        () =>
        {
            print("2nd has stopped");


        }));

        }));

    }

    //private void Fill(float f)
    //{
    //    fillImage.fillAmount = f;
    //}

    //private void Complete()
    //{
    //    print("Fill Has Completed");
    //}

   IEnumerator FillImage(System.Action<float> onFill,System.Action completeCallBack)
    {
        float t = 0;
        while(t<=1)
        {
            t += Time.deltaTime;
            onFill?.Invoke(t);
            yield return null;
        }
        completeCallBack?.Invoke();
    }

}
