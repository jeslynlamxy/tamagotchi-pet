using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoundData
{
    public string name;
    public Question[] questions;
    public int finalScore { get; set; }
    public int rewardedFood { get; set; }
    public int rewardedWater { get; set; }
}
