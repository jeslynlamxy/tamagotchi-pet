using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    public Stat(int statId, int questionId, int timing, bool isCorrect)
    {
        this.statId = statId;
        this.questionId = questionId;
        this.timing = timing;
        this.isCorrect = isCorrect;
    }
    public int statId { get; set; }
    public int questionId { get; set; }
    public int timing { get; set; }
    public bool isCorrect { get; set; }
}