using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentLoginController : MonoBehaviour
{
    private string username;
    private string password;
    private string test;
    UserHttpController userHttp = new UserHttpController();
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
        //API call to backend return studentId to be saved in playerprefs
        // //API call to backend return teacherId to be saved in playerprefs
        // Student.userName = username;
        // test = Student.userName;
        // Debug.Log(test);
        var user = userHttp.readUser();
        Debug.Log(user.Title);

    }



}
