using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HomePage : MonoBehaviour
{
    public TMP_Text Name;
    public TMP_Text email;
    public TMP_Text password;

    public static HomePage homepage;

    private void Awake()
    {
        homepage = this;
    }
}
