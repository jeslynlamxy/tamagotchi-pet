using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Pet
{
    public Pet(string petName, int petId, string petPowerup, int petCurrentFood, int petCurrentWater)
    {
        this.petName = petName;
        this.petId = petId;
        this.petPowerup = petPowerup;
        this.petCurrentFood = petCurrentFood;
        this.petCurrentWater = petCurrentWater;
    }
    public string petName { get; set; }
    public int petId { get; set; }
    public string petPowerup { get; set; }
    public bool isPetUnlocked { get; set; }
    public int petCurrentWater { get; set; }
    public int petCurrentFood { get; set; }
    public int petNumOfGamesToUnlock { get; set; }


}