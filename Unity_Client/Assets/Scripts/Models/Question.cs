using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;
using System.Linq;


[System.Serializable]
public class Question
{
    public Question(string questionId, string questionText, int answerIndex, List<string> answersText, string worldTopic, string specificSection, string questionStandard)
    {
        this.questionId = questionId;
        this.questionText = questionText;
        this.answerIndex = answerIndex;
        this.answersText = answersText;
        this.worldTopic = worldTopic;
        this.specificSection = specificSection;
        this.questionStandard = questionStandard;

    }
    public string questionId { get; set; }
    public string questionText { get; set; }
    public int answerIndex { get; set; }
    public List<string> answersText { get; set; }
    public string worldTopic { get; set; }
    public string specificSection { get; set; }
    public string questionStandard { get; set; } // simple and complex

    public Question(string questionId)
    {
        this.questionId = questionId;
    }
    public Question(JSONNode jsonQ)
    {
        answersText = new List<string>();
        specificSection = jsonQ["specificSection"];
        questionText = jsonQ["questionText"];
        questionStandard = jsonQ["questionStandard"];
        worldTopic = jsonQ["worldTopic"];
        questionId = jsonQ["questionId"];
        answerIndex = int.Parse(jsonQ["answerId"]);
        for (int i = 0; i < jsonQ["answersText"].Count; i++)
        {
            answersText.Add(jsonQ["answersText"][i]);
        }
    }

    public Question(string worldTopic, string specificSection)
    {
        this.worldTopic = worldTopic;
        this.specificSection = specificSection;
        answersText = new List<string>();
        answerIndex = 0;
        questionId = "";
        questionText = "";
        questionStandard = "easy";
    }


    public Question() { }
}
