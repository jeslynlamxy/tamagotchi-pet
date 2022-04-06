using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using TMPro;
using System;
using System.Threading;

public class DesignMyGameManager2 : MonoBehaviour
{
    private DataManager dataController;
    private static  string gameTitle;
    private static  string gameDescription;

   [SerializeField]
    public Text successMsg;
    private HttpManager http;
    public static CustomGame CustomGameInstance;
    public static string ID="";
    public static DesignMyGameManager1 DMGScript1;
  
    void Start()
    {   
        successMsg.gameObject.SetActive(false);
        dataController = FindObjectOfType<DataManager>();
        CustomGameInstance= dataController.GetCustomGame();
        CustomGameInstance.questionList = DesignMyGameManager1.gameQnList;
    }
    public void postGame(){
        dataController = FindObjectOfType<DataManager>();
        CustomGameInstance= dataController.GetCustomGame();
        CustomGameInstance.questionList = DesignMyGameManager1.gameQnList;
        CustomGameInstance.customeGameId ="ABD34";
        CustomGameInstance.customeGameName ="Requirement Analysis";
        CustomGameInstance.customGameDescription="Just do it for fun";


        Debug.Log("Posting game to database now");
        http = new HttpManager();
        var url = "http://172.21.148.165/add_Assignment";
        // var response = http.Post(url, CustomGameInstance);
        Debug.Log("Assignment Posted Successfully");
    }

    public void saveButton(){
        postGame();
        Debug.Log("Positng done");
        successMsg.gameObject.SetActive(true);
        successMsg.text = "Posted successfully!, \n\n Assignment Code is: \n" + CustomGameInstance.customeGameId;
    }
// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void readNameInput(string title){
        gameTitle = title;
        Debug.Log(title);
    }

    public void readDescriptionInput(string description){
        gameDescription = description;
        Debug.Log(description);
    }

// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void backButton(){
        SceneManager.LoadScene("DesignMyGame-P1");
    }
}
