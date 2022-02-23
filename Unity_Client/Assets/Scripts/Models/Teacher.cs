using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Teacher
{

    [SerializeField]
    private string userName;


    public Teacher(string username)
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