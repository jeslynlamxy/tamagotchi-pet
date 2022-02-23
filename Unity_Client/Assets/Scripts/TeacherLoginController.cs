using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherLoginController : MonoBehaviour
{
    private string username;
    private string password;
    private Teacher teacher;

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
        teacher = new Teacher(username);
        // user.setUserName(username);
        test = teacher.getUserName();
        Debug.Log(test);
        // Debug.Log("Login Successful");
    }

}
