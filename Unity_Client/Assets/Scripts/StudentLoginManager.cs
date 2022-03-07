using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class StudentLoginManager : MonoBehaviour
{
    private string usernameInput;
    private bool usernameValid;
    private bool passwordValid;
    private string passwordEncrypted;
    private PasswordManager pwd;
    private HttpManager http;
    private SceneLoaderManager scene;
    public Text MessageLabel;
    public Student student;


    public void ReadUsernameInput(string s)
    {

        Debug.Log(s);
        usernameValid = IsUsernameValid(s);
        if (usernameValid)
        {
            usernameInput = s;
        }
        else
        {
            MessageLabel.text = "Enter username of at least 6 chars with letters";
        }
    }

    public void ReadPasswordInput(string s)
    {
        Debug.Log(s);
        passwordValid = IsPasswordValid(s);
        if (passwordValid)
        {
            pwd = new PasswordManager();
            passwordEncrypted = pwd.AESEncryption(s);
            Debug.Log(passwordEncrypted);
        }
        else
        {
            MessageLabel.text = "Enter password of at least 8 chars";
        }
    }
    public bool IsUsernameValid(string un)
    {
        if ((un.Length >= 6) & (Regex.IsMatch(un, @"^[a-zA-Z]+$")))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public bool IsPasswordValid(string pw)
    {
        // if ((pw.Length >= 8) & (Regex.IsMatch(pw, @"^[a-zA-Z]+$")) & (Regex.IsMatch(pw, @"^-?\d+$")))
        if (pw.Length >= 8)
        {
            return true;
        }
        else
        {
            return false;
        }

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
        if (usernameValid & passwordValid)
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
                PlayerPrefs.SetString("username", usernameInput);
                scene.LoadStudentWelcomeUI();
                PlayerPrefs.SetInt("studentRegister", 0);
            }

        }
        // else
        // {
        //     MessageLabel.text = "Please enter details again";
        // }

    }
    public void RegisterAndLogin()
    {
        if (usernameValid & passwordValid)
        {
            studentLogin = new StudentLoginDetails(usernameInput, passwordEncrypted);
            http = new HttpManager();
            scene = new SceneLoaderManager();
            var url = "http://172.21.148.165/register_student";
            var response = http.Post(url, studentLogin);
            Debug.Log(response);
            response = response.Substring(1, response.Length - 2);
            MessageLabel.text = response;

            if (response == "User successfully registered")
            {
                PlayerPrefs.SetString("studentUsername", usernameInput);
                CreateNewStudentData();
                scene.LoadStudentWelcomeUI();
            }

        }
        else
        {
            MessageLabel.text = "Please enter details again";
        }

    }
    public void CreateNewStudentData()
    {
        //(string petName, int petSkinId, string petPowerup, int petCurrentHunger, int petCurrentThirst)
        var defaultPet1 = new Pet("Pet1", 0, "Add 5 Seconds", 5, 5);
        var defaultPet2 = new Pet("Pet2", 0, "1 Retry Question", 3, 3);
        var petList = new List<Pet>();
        petList.Add(defaultPet1);
        petList.Add(defaultPet2);

        student = new Student(usernameInput, 0, petList, 3, 3);
        // post to backend studentdata

    }



}

