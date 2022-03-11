using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoundData
{
    public int roundId { get; set; }
    public string WorldTopic { get; set; }
    public string SpecificSection { get; set; }
    public string StartingDifficulty { get; set; }
    public int TotalTimesAnswered { get; set; }
    public int TotalTimesCorrect { get; set; }
    public Question[] questions { get; set; }
    public Stat[] stats { get; set; }
    public int rewardedWater { get; set; }
    public int finalScore { get; set; }
    public int rewardedFood { get; set; }
    public int rewardedWater { get; set; }

}
