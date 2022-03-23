using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using TMPro;

public class PostAssignmentManager2 : MonoBehaviour
{
    private string assignmentTitle;
    private string assignmentDescription;

    private string assignmentMark;
    private string assignmentTopic;
    private int dueYear;
    private int dueMonth;
    private int dueDay;
    private int dueHour;

    public Text successMsg;
    void Start()
    {
        
    }

    public void readNameInput(string title){
        assignmentTitle = title;
        Debug.Log(title);
    }

    public void readDescriptionInput(string description){
        assignmentDescription = description;
        Debug.Log(description);
    }

    public void readTotalMarkInput(string totalMark){
        assignmentMark = totalMark;
        Debug.Log(totalMark);
    }

    public void handleTopicDropdown(int val){

        if (val == 0){
            assignmentTopic = "";
        }
        if (val==1){
            assignmentTopic = "REQUIREMENT%30ANALYSIS";
        }
        if (val==3){
            assignmentTopic = "DESIGN%30PHASE";
            Debug.Log("World 3: " + assignmentTopic);
        }
        if (val==3){
            assignmentTopic = "IMPLEMENTATION%30PHASE";
        }
        Debug.Log("topic " + assignmentTopic + " is selected.");
    }

    public void handleDueYearDropDown(int val){
        if (val == 0){
            dueYear = 2021;
        }
        if (val==1){
            dueYear = 2021;
        }
        if (val==3){
            dueYear = 2022;
        }
        if (val==3){
            dueYear = 2023;
        }
        Debug.Log(dueYear);
    }

    public void handleDueMonthDropdown(int val){
        dueMonth = val+1;
    }
    public void handleDueDayDropDown(int val){
        dueDay = val+1;
    }
    public void handleDueTimeDropdown(int val){
        dueHour = val;
    }


    public void SelectTargetStudentButton(){
        SceneManager.LoadScene("PostAssignment-P3");
    }
    
    public void backButton(){
        SceneManager.LoadScene("PostAssignment-P1");
    }

    public void postButton(){
        successMsg = GameObject.Find("SuccessMsg").GetComponent<Text>();
        successMsg.text = "Posted successfully!";
        SceneManager.LoadScene("TeacherWelcomeUI");
    }

    

}
