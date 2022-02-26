using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CreateAccountController : MonoBehaviour
{
    public string x;
    public void CreateAccount()
    {
        string x = PlayerPrefs.GetString("ToggleSelected");
        Debug.Log(x);
    }
}
