using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Student;
using static Pet;

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
        //API call to backend 

        // put placeholders for now, to be replaced by http req result
        List<Pet> PetList = new List<Pet>();
        PetList.Add(new Pet("cat", 1, "extra 5 seconds", 10, 2));
        List<string> LvlList = new List<string>();
        LvlList.Add("SRS");

        StudentData.userName = "poggers";
        StudentData.id = 1;
        StudentData.overallScore = 800;
        StudentData.petsUnlocked = PetList;
        StudentData.currentFood = 30;
        StudentData.currentWater = 15;
        StudentData.NumOfGamesCompleted = 22;
        StudentData.levelsUnlocked = LvlList;

    }
    public void RegisterAndLogin()
    {


    }



}
