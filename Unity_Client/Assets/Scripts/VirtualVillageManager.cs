using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualVillageManager : MonoBehaviour
{
    public Text usernameLabel;
    public string username;
    public Student student;
    private HttpManager http;
    private int displayPetsIndex;
    public Image petImage;
    public Sprite[] petSprites;
    public Text petFoodAmt;
    public Text petWaterAmt;
    public Text petSkill;
    public Text currentWater;
    public Text currentFood;
    public Text petStatusLabel;
    public Button changeSkinButton;
    public Button provideFoodButton;
    public Button provideWaterButton;

    void Start()
    {
        username = PlayerPrefs.GetString("studentUsername", "student");
        UpdateStudentUsername(username);
        displayPetsIndex = PlayerPrefs.GetInt("currentPetsIndex", 0);
        GetStudentData();
        UpdatePetDisplay();
        UpdateSupplyDisplay();
    }
    public void UpdateStudentUsername(string s)
    {
        var label = s + "'s virtual village";
        usernameLabel.text = label;
    }
    public void GetStudentData()
    {
        //(string petName, int petSkinId, string petPowerup, int petCurrentHunger, int petCurrentThirst)
        var defaultPet1 = new Pet("Pet1", 0, "Add 5 Seconds", 8, 5);
        var defaultPet2 = new Pet("Pet2", 0, "Add 1 Health", 3, 3);
        var petList = new List<Pet>();
        petList.Add(defaultPet1);
        petList.Add(defaultPet2);

        student = new Student(username, 0, petList, 3, 3);
        // post to backend studentdata

    }
    public void NextPet()
    {
        displayPetsIndex += 1;
        if (displayPetsIndex >= student.petsUnlocked.Count)
        {
            displayPetsIndex = student.petsUnlocked.Count;
        }
        PlayerPrefs.SetInt("currentPetsIndex", displayPetsIndex);
        UpdatePetDisplay();
    }

    public void PrevPet()
    {
        displayPetsIndex -= 1;
        if (displayPetsIndex <= 0)
        {
            displayPetsIndex = 0;
        }
        PlayerPrefs.SetInt("currentPetsIndex", displayPetsIndex);
        UpdatePetDisplay();
    }
    public void UpdatePetDisplay()
    {
        if (displayPetsIndex < student.petsUnlocked.Count)
        {
            var petSkinId = student.petsUnlocked[displayPetsIndex].petSkinId;
            petImage.sprite = petSprites[displayPetsIndex * 3 + petSkinId];
            var petFood = student.petsUnlocked[displayPetsIndex].petCurrentFood * 10;
            var petFoodPercent = petFood.ToString();
            petFoodAmt.text = petFoodPercent + "%";
            var petWater = student.petsUnlocked[displayPetsIndex].petCurrentWater * 10;
            var petWaterPercent = petWater.ToString();
            petWaterAmt.text = petWaterPercent + "%";
            petSkill.text = student.petsUnlocked[displayPetsIndex].petPowerup;
            petStatusLabel.text = "";
            changeSkinButton.interactable = true;
            provideWaterButton.interactable = true;
            provideFoodButton.interactable = true;

        }
        else if (displayPetsIndex == student.petsUnlocked.Count)
        {
            petStatusLabel.text = "locked";
            petImage.sprite = petSprites[displayPetsIndex * 3];
            petFoodAmt.text = "locked";
            petWaterAmt.text = "locked";
            petSkill.text = "Add 10 seconds";
            changeSkinButton.interactable = false;
            provideWaterButton.interactable = false;
            provideFoodButton.interactable = false;
        }


    }

    public void UpdateSupplyDisplay()
    {
        currentFood.text = student.currentFood + "/10";
        currentWater.text = student.currentWater + "/10";
    }

    public void ProvideWater()
    {
        if ((displayPetsIndex < student.petsUnlocked.Count) & (student.currentWater > 0) & (student.petsUnlocked[displayPetsIndex].petCurrentWater < 10))
        {
            student.currentWater -= 1;
            student.petsUnlocked[displayPetsIndex].petCurrentWater += 1;
            UpdatePetDisplay();
            UpdateSupplyDisplay();
        }
    }
    public void ProvideFood()
    {
        if ((displayPetsIndex < student.petsUnlocked.Count) & (student.currentFood > 0) & (student.petsUnlocked[displayPetsIndex].petCurrentFood < 10))
        {
            student.currentFood -= 1;
            student.petsUnlocked[displayPetsIndex].petCurrentFood += 1;
            UpdatePetDisplay();
            UpdateSupplyDisplay();

        }
    }
}
