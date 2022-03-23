using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using TMPro;

public class DesignMyGameManager2 : MonoBehaviour
{
    private string gameTitle;
    private string gameDescription;


    // public Text successMsg;
    void Start()
    {
        
    }

    public void readNameInput(string title){
        gameTitle = title;
        Debug.Log(title);
    }

    public void readDescriptionInput(string description){
        gameDescription = description;
        Debug.Log(description);
    }

  
    public void backButton(){
        SceneManager.LoadScene("DesignMyGame-P1");
    }

    // public void postButton(){
    //     successMsg = GameObject.Find("SuccessMsg").GetComponent<Text>();
    //     successMsg.text = "Posted successfully!";
    //     SceneManager.LoadScene("StudentWelcomeUI");
    // }

    

}
