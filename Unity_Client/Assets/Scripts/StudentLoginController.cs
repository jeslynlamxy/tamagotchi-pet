using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentLoginController : MonoBehaviour
{
    private string username;
    private string password;
    private Student student;

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

    public void Login()
    {
        student = new Student(username);
        // user.setUserName(username);
        test = student.getUserName();
        Debug.Log(test);
        // Debug.Log("Login Successful");
    }

}
