using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;
using System.Linq;


[Serializable]
public class Question
{
    public Question(string questionId, string questionText, int answerIndex, List<string> answersText, string worldTopic, string specificSection, string questionStandard, string difficultyStandard)
    {
        
        this.questionText = questionText;
        this.answerIndex = answerIndex;
        this.answersText = answersText;
        this.worldTopic = worldTopic;
        this.specificSection = specificSection;
        this.questionStandard = questionStandard;
        this.difficultyStandard = difficultyStandard;
        this.questionId = questionId;


    }
    
    public string questionText { get; set; }
    public int answerIndex { get; set; }
    public List<string> answersText { get; set; }
    public string worldTopic { get; set; }
    public string specificSection { get; set; }
    public string questionStandard { get; set; } // simple and complex
    public string difficultyStandard { get; set; }
    public string questionId { get; set; }

    public Question(string questionId){
        this.questionId = questionId;
    }
    [field:NonSerialized]
    public Question(JSONNode jsonStoryQ)
    {
        answersText = new List<string>();
        specificSection = jsonStoryQ["specificSection"];
        questionText = jsonStoryQ["questionText"];
        questionStandard = jsonStoryQ["questionStandard"];
        worldTopic = jsonStoryQ["worldTopic"];
        questionId = jsonStoryQ["questionId"];
        answerIndex = int.Parse(jsonStoryQ["answerIndex"]);
        for (int i = 0; i < jsonStoryQ["answersText"].Count; i++)
        {
            answersText.Add(jsonStoryQ["answersText"][i]);
        }
    }

    public Question(string worldTopic, string specificSection){
        this.worldTopic = worldTopic;
        this.specificSection = specificSection;
        answersText = new List<string>();
        answerIndex = 0;
        questionId = "30";
        questionText = "";
        questionStandard = "simple";
        difficultyStandard = "easy";
    }
}
