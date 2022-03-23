using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;
using System.Linq;
using UnityEngine.Networking;

// Handles GET, POST, PUT and DELETE requests for Story Mode Questions
public class QuestionManager : MonoBehaviour{
    public Question question;
    private HttpManager http;
    public static Boolean getStoryQDone;
    public static Boolean deleteStoryQDone;
    public static Boolean updateStoryQDone;
    public static JSONNode jsonNodeStoryQ;

    public QuestionManager()
    {
        getStoryQDone = false;
        deleteStoryQDone = false;
        updateStoryQDone = false;
    }


    // Gets story mode question by its ID
    public IEnumerator getStoryQ(string questionId)
    {
        getStoryQDone = false;
        API_Connection api = new API_Connection();
        yield return StartCoroutine(api.GetData("get_question_byid?question_id=" + questionId, null, s => {
            jsonNodeStoryQ = JSON.Parse(s);
        }));
        getStoryQDone = true;
    }



    // Updates an existing story mode question
    public void updateStoryQ(Question question)
    {
        http = new HttpManager();
        //scene = new SceneLoaderManager();
        var url = "http://172.21.148.165/update_question";
        var response = http.Post(url, question);
        Debug.Log(response);
    }



    public void addStoryQ(Question question)
    {
            http = new HttpManager();
            //scene = new SceneLoaderManager();
            var url = "http://172.21.148.165/add_question";
            var response = http.Post(url, question);
            Debug.Log(response);
            //response = response.Substring(1, response.Length - 2);

        }

    // Deletes a story mode question
    public IEnumerator deleteStoryQ(Question storyModeQ)
    {
        deleteStoryQDone = false;
        API_Connection conn = new API_Connection();
        yield return StartCoroutine(conn.DeleteData("StoryModeQuestion/" + storyModeQ.questionId, s => {
            Debug.Log(JSON.Parse(s));
        }));
        deleteStoryQDone = true;
    }
}

    

