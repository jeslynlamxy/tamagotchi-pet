using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    public Stat(int statId, int roundId, int questionId, int timing, int currentHealth, bool isCorrect)
    {
        this.statId = statId;
        this.roundId = roundId;
        this.questionId = questionId;
        this.timing = timing;
        this.currentHealth = currentHealth;
        this.isCorrect = isCorrect;
    }
    public int statId { get; set; }
    public int roundId { get; set; }
    public int questionId { get; set; }
    public int timing { get; set; }
    public int currentHealth { get; set; }
    public bool isCorrect { get; set; }
}