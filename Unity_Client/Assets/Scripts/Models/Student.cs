using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static User;

[System.Serializable]
public class Student : User
{
    public Student(string username, int highestScore, List<Pet> petsUnlocked, int currentFood, int currentWater)
    {
        this.username = username;
        this.highestScore = highestScore;
        this.petsUnlocked = petsUnlocked;
        this.currentFood = currentFood;
        this.currentWater = currentWater;
    }
    public int highestScore { get; set; } // for leaderboard ?
    public List<Pet> petsUnlocked { get; set; }
    public int currentFood { get; set; }
    public int currentWater { get; set; }
    public int NumOfGamesCompleted { get; set; }
    public List<string> levelsUnlocked { get; set; }
}