using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Question
{
    public Question(string QuestionString, List<string> AnwerList, int CorrectIndex)
    {
        this.QuestionString = QuestionString;
        this.AnwerList = AnwerList;
        this.CorrectIndex = CorrectIndex;
    }
    public string QuestionString { get; set; }
    public List<string> AnswerList { get; set; }
    public int CorrectIndex { get; set; }
}