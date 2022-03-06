using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static User;

[System.Serializable]
public class Student : User
{
    public int highestScore { get; set; } // for leaderboard ?
    public List<Pet> petsUnlocked { get; set; }
    public int currentFood { get; set; }
    public int currentWater { get; set; }
    public int NumOfGamesCompleted { get; set; }
    public List<string> levelsUnlocked { get; set; } // every world has several levels, should be List<Level>


}