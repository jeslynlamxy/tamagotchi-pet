using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetChangeSkinManager : MonoBehaviour
{
    public string username;
    private int displayPetsIndex;
    public Student student;
    public Image[] petSkinChoices;
    public Sprite[] petSkinSprites;
    public Text header;

    // Start is called before the first frame update
    void Start()
    {
        username = PlayerPrefs.GetString("studentUsername", "student");
        displayPetsIndex = PlayerPrefs.GetInt("currentPetsIndex", 0);
        // displayPetsIndex = 0;
        GetStudentData();
        UpdateChangeSkinDisplay();

    }
    public void GetStudentData()
    {
        //(string petName, int petId, string petPowerup, int petCurrentHunger, int petCurrentThirst)
        var defaultPet1 = new Pet("Pet1", 0, "Add 5 Seconds", 5, 5);
        var defaultPet2 = new Pet("Pet2", 1, "1 Retry Question", 3, 3);
        var petList = new List<Pet>();
        petList.Add(defaultPet1);
        petList.Add(defaultPet2);

        student = new Student(username, 0, petList, 3, 3);
        // post to backend studentdata

    }
    public void NextPet()
    {
        displayPetsIndex += 1;
        if (displayPetsIndex >= student.petsUnlocked.Count - 1)
        {
            displayPetsIndex = student.petsUnlocked.Count - 1;
        }
        PlayerPrefs.SetInt("currentPetsIndex", displayPetsIndex);
        UpdateChangeSkinDisplay();


    }

    public void PrevPet()
    {
        displayPetsIndex -= 1;
        if (displayPetsIndex <= 0)
        {
            displayPetsIndex = 0;
        }
        PlayerPrefs.SetInt("currentPetsIndex", displayPetsIndex);
        UpdateChangeSkinDisplay();
    }
    public void UpdateChangeSkinDisplay()
    {
        header.text = "change skin for: " + student.petsUnlocked[displayPetsIndex].petName;
        petSkinChoices[0].sprite = petSkinSprites[displayPetsIndex * 3 + 0];
        petSkinChoices[1].sprite = petSkinSprites[displayPetsIndex * 3 + 1];
        petSkinChoices[2].sprite = petSkinSprites[displayPetsIndex * 3 + 2];
    }

    public void SkinOneSelected()
    {
        student.petsUnlocked[displayPetsIndex].petSkinId = 0;
    }
    public void SkinTwoSelected()
    {
        student.petsUnlocked[displayPetsIndex].petSkinId = 1;
    }
    public void SkinThreeSelected()
    {
        student.petsUnlocked[displayPetsIndex].petSkinId = 2;
    }




}
