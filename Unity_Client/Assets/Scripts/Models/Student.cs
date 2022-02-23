using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Student
{

    [SerializeField]
    private string userName;


    public Student(string username)
    {
        this.userName = username;
    }


    public string getUserName()
    {
        return this.userName;
    }

    public void setUserName(string userName)
    {
        this.userName = userName;
    }



}