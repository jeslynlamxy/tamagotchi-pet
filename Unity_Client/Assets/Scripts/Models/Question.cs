using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Question
{
    public int QuestionId;
    public string QuestionText;
    public int AnswerIndex;
    public string[] AnswersText;
    public string WorldTopic;
    public string SpecificSection;
    public string DifficultyLevel;
}
