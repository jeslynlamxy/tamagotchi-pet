using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Student;

public class StudentLoginController : MonoBehaviour
{
    private string username;
    private string passwordEncrypted;
    private string test;
    private PasswordController pwd;

    public void ReadUsernameInput(string s)
    {
        username = s;
        Debug.Log(s);
    }

    public void ReadPasswordInput(string s)
    {
        Debug.Log(s);
        pwd = new PasswordController();
        passwordEncrypted = pwd.AESEncryption(s);
        Debug.Log(passwordEncrypted);
    }

    public void Login()
    {
        //API call to backend return studentId to be saved in playerprefs
        // //API call to backend return teacherId to be saved in playerprefs
        // Student.userName = username;
        // test = Student.userName;
        // Debug.Log(test);
        // var user = userHttp.readUser();
        // Debug.Log(user.Title);

    }
    public void RegisterAndLogin()
    {
        //API call to backend return studentId to be saved in playerprefs
        // //API call to backend return teacherId to be saved in playerprefs
        // Student.userName = username;
        // test = Student.userName;
        // Debug.Log(test);
        // var user = userHttp.readUser();
        // Debug.Log(user.Title);

    }



}
