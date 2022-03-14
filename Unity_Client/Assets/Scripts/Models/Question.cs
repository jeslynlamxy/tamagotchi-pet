using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
}
