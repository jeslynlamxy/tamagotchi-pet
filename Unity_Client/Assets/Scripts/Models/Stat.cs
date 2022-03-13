using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    public Stat(int statId, int roundId, int questionId, string studentUsername, int timing, int currentHealth, bool isSkillLeft)
    {
        this.statId = statId;
        this.roundId = roundId;
        this.questionId = questionId;
        this.studentUsername = studentUsername;
        this.timing = timing;
        this.currentHealth = currentHealth;
        this.isSkillLeft = isSkillLeft;
    }
    public int statId { get; set; }
    public int roundId { get; set; }
    public int questionId { get; set; }
    public string studentUsername { get; set; }
    public int timing { get; set; }
    public int currentHealth { get; set; }
    public bool isSkillLeft { get; set; }
}