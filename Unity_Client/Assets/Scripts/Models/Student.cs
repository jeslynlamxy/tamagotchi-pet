using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static User;

[System.Serializable]
public class Student : User
{
    public int overallScore { get; set; }
    public List<Pet> petsUnlocked { get; set; }
    public int currentFood { get; set; }
    public int currentWater { get; set; }
    public int NumOfGamesCompleted { get; set; }


}