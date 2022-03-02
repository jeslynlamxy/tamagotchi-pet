using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentLoginManager : MonoBehaviour
{
    private string usernameInput;
    private string passwordEncrypted;
    private PasswordManager pwd;
    private HttpManager http;
    private SceneLoaderManager scene;
    public Text MessageLabel;


    public void ReadUsernameInput(string s)
    {
        usernameInput = s;
        Debug.Log(s);
    }

    public void ReadPasswordInput(string s)
    {
        Debug.Log(s);
        pwd = new PasswordManager();
        passwordEncrypted = pwd.AESEncryption(s);
        Debug.Log(passwordEncrypted);
    }

    public class StudentLoginDetails
    {
        public StudentLoginDetails(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string username { get; set; }
        public string password { get; set; }

    }
    private StudentLoginDetails studentLogin;
    public void Login()
    {
        studentLogin = new StudentLoginDetails(usernameInput, passwordEncrypted);
        http = new HttpManager();
        scene = new SceneLoaderManager();
        var url = "http://172.21.148.165/login_student";
        var response = http.Post(url, studentLogin);
        Debug.Log(response);
        response = response.Substring(1, response.Length - 2);
        MessageLabel.text = response;

        if (response == "Successfully authenticated")
        {
            scene.LoadStudentWelcomeUI();
        }
    }
    public void RegisterAndLogin()
    {
        studentLogin = new StudentLoginDetails(usernameInput, passwordEncrypted);
        http = new HttpManager();
        var url = "http://172.21.148.165/register_student";
        var response = http.Post(url, studentLogin);
        Debug.Log(response);
        response = response.Substring(1, response.Length - 2);
        MessageLabel.text = response;

        if (response == "User successfully registered")
        {
            scene.LoadStudentWelcomeUI();
        }
    }



}
