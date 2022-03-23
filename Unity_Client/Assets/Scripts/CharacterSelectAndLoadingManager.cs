using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Newtonsoft.Json;
using static Question;
public class CharacterSelectAndLoadingManager : MonoBehaviour
{
    public Student student;
    private HttpManager http;
    private int displayPetsIndex;
    public string username;
    public Image petImage;
    public Sprite[] petSprites;
    public Text petSkill;
    private DataManager dataController;

    private List<Question> questionListData;

    private SinglePlayerRoundData SinglePlayerInstance;
    private MultiPlayerRoundData MultiPlayerInstance;



    void Start()
    {
        dataController = FindObjectOfType<DataManager>();
        username = dataController.username;
        displayPetsIndex = 0;
        GetStudentData();
        UpdatePetDisplay();

        SinglePlayerInstance = dataController.GetSinglePlayerInstance();
        MultiPlayerInstance = dataController.GetMultiPlayerInstance();
    }

    public void GetStudentData()
    {
        http = new HttpManager();
        var url = "http://172.21.148.165/get_userData?username=" + username; // add query parameter using username?
        var responseStr = http.Post(url, "");
        student = JsonConvert.DeserializeObject<Student>(responseStr);
    }

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
        petSkill.text = student.petsUnlocked[displayPetsIndex].petPowerup;
        dataController.selectedPetIndex = displayPetsIndex;
    }

    // private List<string> tamagotchiList = new List<string>
    //         {"a", "b", "c"}; // tbc
    // private int currentPointer = 0;

    // int mod(int a, int n) {
    //     return ((a%n)+n) % n;
    // }

    // public void LoadCharacterInPanel(int currentPointer) {
    //     int tamagotchiIndex = mod(currentPointer, tamagotchiList.Count);
    //     // get tamagotchi and display in screen
    //     // idk how lmao
    //     Debug.Log(tamagotchiIndex.ToString());
    //     Debug.Log(tamagotchiList[tamagotchiIndex]);
    // }

    // public void NextButtonPress()
    // {
    //     currentPointer += 1;
    //     LoadCharacterInPanel(currentPointer);
    // }

    // public void PreviousButtonPress()
    // {
    //     currentPointer -= 1;
    //     LoadCharacterInPanel(currentPointer);
    // }

    public void SetSinglePlayerQuestions(string world, string section, string level)
    {
        // considering the world section level do the item below
        // if (level == "easy")
        // {
        //     // get 6 simple questions from server
        //     // get 2 complex questions from server
        // }
        // else if (level == "medium")
        // {
        //     // get 4 simple questions from server
        //     // get 4 complex questions from server
        // }
        // else if (level == "hard")
        // {
        //     // get 2 simple questions from server
        //     // get 6 complex questions from server
        // }

        string worldUri = System.Web.HttpUtility.UrlPathEncode(world);
        // var url = "http://172.21.148.165/get_question_filtered?world=" + worldUri + "&section=1&limit=8";
        var url = "http://172.21.148.165/get_question_filtered?world=REQUIREMENT%20ANALYSIS&section=1&limit=8";
        var responseStr = http.Post(url, "");
        Debug.Log(url);
        Debug.Log(responseStr);

        var questionList = JsonConvert.DeserializeObject<List<Question>>(responseStr);
        SinglePlayerInstance.questionList = questionList;

        // sample only, need to replace with backend stuffs above
        // var answersText = new List<string>();
        // answersText.Add("4");
        // answersText.Add("3");
        // answersText.Add("2");
        // answersText.Add("1");

        // var question1 = new Question("0", "2+2", 0, answersText, "requirements", "1", "simple");
        // var question2 = new Question("0", "3x1", 1, answersText, "requirements", "1", "complex");

        // var questionList = new List<Question>();
        // questionList.Add(question1);
        // questionList.Add(question2);


    }

    public async void SetMultiPlayerQuestions(string world, string section, string level)
    {
        // considering the world section level do the item below
        // get single player game in data base with same world section level
        // get the stat data as well

        // MultiPlayerInstance.opponentRoundId = 

        // sample only, need to replace with backend stuffs above
        var answersText = new List<string>();
        answersText.Add("4");
        answersText.Add("3");
        answersText.Add("2");
        answersText.Add("1");

        var question1 = new Question("0", "2+2", 0, answersText, "requirements", "1", "simple", "easy");
        var question2 = new Question("1", "3x1", 1, answersText, "requirements", "1", "complex", "easy");

        var questionList = new List<Question>();
        questionList.Add(question1);
        questionList.Add(question2);

        MultiPlayerInstance.questionList = questionList;
        var stat1 = new Stat(dataController.generateUID(), dataController.generateUID(), "0", "meowmeow", 15, true, 2, true);
        var stat2 = new Stat(dataController.generateUID(), dataController.generateUID(), "1", "meowmeow", 20, true, 2, true);

        var opponentStatList = new List<Stat>();
        opponentStatList.Add(stat1);
        opponentStatList.Add(stat2);

        MultiPlayerInstance.opponentStatList = opponentStatList;
    }



    public void StartGameButtonClicked()
    {
        // maybe can show loading animation
        string gameType = PlayerPrefs.GetString("gameTypeSelected", "Nil");
        string world = PlayerPrefs.GetString("worldSelected", "Nil");
        string section = PlayerPrefs.GetString("sectionSelected", "Nil");
        string level = PlayerPrefs.GetString("levelSelected", "Nil");

        if (gameType == "Single")
        {
            SinglePlayerInstance.sldcWorld = world;
            SinglePlayerInstance.specificSection = section;
            SinglePlayerInstance.difficultyLevel = level;

            SetSinglePlayerQuestions(world, section, level);
            SceneManager.LoadScene("SinglePlayerGameUI");
        }

        else if (gameType == "Multi")
        {
            MultiPlayerInstance.sldcWorld = world;
            MultiPlayerInstance.specificSection = section;
            MultiPlayerInstance.difficultyLevel = level;

            SetMultiPlayerQuestions(world, section, level);
            SceneManager.LoadScene("MultiPlayerGameUI");
        }

        else
        {
            Debug.Log("Error!");
        }
    }

}
