using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateAccountController : MonoBehaviour
{
    private string username;
    private string password;
    private string test;

    public void ReadUsernameInput(string s)
    {
        username = s;
        Debug.Log(s);
    }

    public void ReadPasswordInput(string s)
    {
        password = s;
        Debug.Log(s);
    }
    // private string acctType;
    // private string username;
    // private string passwordEncrypted;

    // private PasswordController pwd;



    // public void ReadUsername(string s)
    // {
    //     username = s;
    //     Debug.Log(username);
    // }

    // public void ReadPassword(string s)
    // {
    //     passwordEncrypted = s;
    //     pwd = new PasswordController();
    //     Debug.Log(passwordEncrypted);
    //     passwordEncrypted = pwd.AESEncryption(s);
    //     Debug.Log(passwordEncrypted);
    // }

    // public void CreateAccount()
    // {
    //     acctType = PlayerPrefs.GetString("ToggleSelected");
    //     Debug.Log(acctType + username + passwordEncrypted);


    //     if (acctType == "student")
    //     {
    //         // newStudent.password = password;
    //         // post to server
    //     }
    //     else
    //     {
    //         // newTeacher.userName = username;
    //         // newTeacher.password = password;
    //     }
    // }
}
