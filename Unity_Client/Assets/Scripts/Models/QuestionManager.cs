using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;
using System.Linq;
using UnityEngine.Networking;
using Newtonsoft.Json;

// Handles GET, POST, PUT and DELETE requests for Story Mode Questions
public class QuestionManager : MonoBehaviour
{
    public static Boolean getQDone;
    public static Boolean updateQDone;
    public static Boolean addQDone;
    public static Boolean deleteQDone;
    public static JSONNode jsonNodeQ;
    public static string selectedWorld = World_Select_Script.worldChoice;
    public static string selectedSectionUnformat = Section_Select_Script.sectionChoice;
    public static string selectedSection = selectedSectionUnformat.Replace(" ", "%20");
    public Question question;
    private HttpManager http;

    // Gets story mode question by its ID
    public void getQ(Question Q)
    {

        http = new HttpManager();
        var url = "http://172.21.148.165/get_question_filtered?world=" + selectedWorld + "&section=" + selectedSection; // add query parameter using username
        var responseStr = http.Post(url, "");
        question = JsonConvert.DeserializeObject<Question>(responseStr);
    }

    // Adds a story mode question
    public void addQ(Question Q)
    {
        http = new HttpManager();
        var url = "http://172.21.148.165/add_question"; // add query parameter using username
        var responseStr = http.Post(url, question);
        Debug.Log(responseStr);
    }

}
