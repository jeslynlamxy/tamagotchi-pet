using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StudentWelcomeManager : MonoBehaviour
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

    void Start()
    {
        username = PlayerPrefs.GetString("studentUsername");
        UpdateStudentUsername(username);
        displayPetsIndex = 0;
        GetStudentData();
        UpdatePetDisplay();
    }

    public void GetStudentData()
    {
        //(string petName, int petSkinId, string petPowerup, int petCurrentHunger, int petCurrentThirst)
        var defaultPet1 = new Pet("Pet1", 0, "Add 5 Seconds", 5, 5);
        var defaultPet2 = new Pet("Pet2", 0, "1 Retry Question", 3, 3);
        var petList = new List<Pet>();
        petList.Add(defaultPet1);
        petList.Add(defaultPet2);

        student = new Student(username, 0, petList, 3, 3);
        // post to backend studentdata
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SingleMultiPlayerSelectionUI");
    }

    public void UpdateStudentUsername(string s)
    {
        var label = "hello, " + s + "!";
        usernameLabel.text = label;
    }

    public void CreateNewStudentData()
    {
        //(string petName, int petId, string petPowerup, int petCurrentHunger, int petCurrentThirst)
        var defaultPet1 = new Pet("Pet1", 0, "Add 5 Seconds", 5, 5);
        var defaultPet2 = new Pet("Pet2", 0, "1 Retry Question", 3, 3);
        var petList = new List<Pet>();
        petList.Add(defaultPet1);
        petList.Add(defaultPet2);

        student = new Student(username, 0, petList, 3, 3);
        // post to backend studentdata

    }

    // public void GetStudentData()
    // {
    //     http = new HttpManager();
    //     var url = "http://172.21.148.165/student_data"; // add query parameter using username?
    //     student = http.Get<Student>(url);
    // }

    public void NextPet()
    {
        displayPetsIndex += 1;
        if (displayPetsIndex >= student.petsUnlocked.Count - 1)
        {
            displayPetsIndex = student.petsUnlocked.Count - 1;
        }
        UpdatePetDisplay();
    }

    public void PrevPet()
    {
        displayPetsIndex -= 1;
        if (displayPetsIndex <= 0)
        {
            displayPetsIndex = 0;
        }
        UpdatePetDisplay();
    }

    public void UpdatePetDisplay()
    {
        var petSkinId = student.petsUnlocked[displayPetsIndex].petSkinId;
        petImage.sprite = petSprites[displayPetsIndex * 3 + petSkinId];
        var petFood = student.petsUnlocked[displayPetsIndex].petCurrentFood * 10;
        var petFoodPercent = petFood.ToString();
        petFoodAmt.text = petFoodPercent + "%";
        var petWater = student.petsUnlocked[displayPetsIndex].petCurrentWater * 10;
        var petWaterPercent = petWater.ToString();
        petWaterAmt.text = petWaterPercent + "%";
    }

}
