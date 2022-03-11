using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SinglePlayerRoundData
{
    public int roundId { get; set; } // tbc
    public int studentId { get; set; } // tbc
    public string sldcWorld { get; set; } // simi sldc stage
    public string specificSection { get; set; } // section 1, 2, 3, 4
    public string difficultyLevel { get; set; } // level 1, 2, 3, 4

    public Pet characterUsed { get; set; } // tbc


    // programmer's end
    public List<Question> questionList { get; set; } // get from backend
    public List<Stat> statList { get; set; } // for data analysis




    // student's world
    public int finalScore { get; set; } 
    public int rewardedFood { get; set; }
    public int rewardedWater { get; set; }

}

