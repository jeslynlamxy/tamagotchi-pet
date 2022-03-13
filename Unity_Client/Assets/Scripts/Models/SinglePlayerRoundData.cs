using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SinglePlayerRoundData
{
    public string roundId { get; set; }
    public string studentId { get; set; }
    public string sldcWorld { get; set; } // different sldc stages
    public string specificSection { get; set; } // section 1, 2, 3, 4
    public string difficultyLevel { get; set; } // level 1, 2, 3, 4
    public Pet characterUsed { get; set; }
    // programmer's end
    public List<Question> questionList { get; set; }
    public List<Stat> statList { get; set; }
    // student's world
    public int finalScore { get; set; } 
    public int rewardedFood { get; set; }
    public int rewardedWater { get; set; }
}

