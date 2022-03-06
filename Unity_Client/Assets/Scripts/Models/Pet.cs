using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Pet
{
    public Pet(string petName, int petId, string petPowerup, int petCurrentHunger, int petCurrentThirst)
    {
        this.petName = petName;
        this.petId = petId;
        this.petPowerup = petPowerup;
        this.petCurrentHunger = petCurrentHunger;
        this.petCurrentThirst = petCurrentThirst;
    }
    public string petName { get; set; }
    public int petId { get; set; }
    public string petPowerup { get; set; }
    public bool isPetUnlocked { get; set; }
    public int petCurrentThirst { get; set; }
    public int petCurrentHunger { get; set; }
    public int petNumOfGamesToUnlock { get; set; }


}