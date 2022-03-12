using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MultiPlayerRoundData
{
    public int multiRoundId { get; set; } // tbc
    public int playerStudentId { get; set; } // tbc
    
    public int opponentRoundId { get; set; } // tbc
    public int opponentStudentId { get; set; } // tbc

    public string sldcWorld { get; set; } // simi sldc stage
    public string specificSection { get; set; } // section 1, 2, 3, 4
    public string difficultyLevel { get; set; } // level 1, 2, 3, 4

    public Pet playerCharacterUsed { get; set; } // tbc
    public Pet opponentCharacterUsed { get; set; } // tbc

    // programmer's end
    public List<Question> questionList { get; set; }
    public List<Stat> opponentStatList { get; set; } 
    public List<Stat> playerStatList { get; set; } // for data analysis

    // student's world
    public int winPoint { get; set; }
    public int finalScore { get; set; } 
    public int rewardedFood { get; set; }
    public int rewardedWater { get; set; }

}