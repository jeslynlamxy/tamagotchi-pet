using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectAndLoadingManager : MonoBehaviour
{
    private DataManager dataController;
    private SinglePlayerRoundData SinglePlayerInstance;
    private MultiPlayerRoundData MultiPlayerInstance;
    void Start()
    {
        dataController = FindObjectOfType<DataManager> ();
        SinglePlayerInstance = dataController.GetSinglePlayerInstance();
        MultiPlayerInstance = dataController.GetMultiPlayerInstance();
    }
    
    private List<string> tamagotchiList = new List<string>
            {"a", "b", "c"}; // tbc
    private int currentPointer = 0;

    int mod(int a, int n) {
        return ((a%n)+n) % n;
    }

    public void LoadCharacterInPanel(int currentPointer) {
        int tamagotchiIndex = mod(currentPointer, tamagotchiList.Count);
        // get tamagotchi and display in screen
        // idk how lmao
        Debug.Log(tamagotchiIndex.ToString());
        Debug.Log(tamagotchiList[tamagotchiIndex]);
    }

    public void NextButtonPress()
    {
        currentPointer += 1;
        LoadCharacterInPanel(currentPointer);
    }

    public void PreviousButtonPress()
    {
        currentPointer -= 1;
        LoadCharacterInPanel(currentPointer);
    }
    public void SetSinglePlayerQuestions(string world, string section, string level){
        // considering the world section level do the item below
        if (level == "easy") {
            // get 6 simple questions from server
            // get 2 complex questions from server
        }
        else if (level == "medium") {
            // get 4 simple questions from server
            // get 4 complex questions from server
        }
        else if (level == "hard") {
            // get 2 simple questions from server
            // get 6 complex questions from server
        }
        
        // sample only, need to replace with backend stuffs above
        var answersText = new List<string>();
        answersText.Add("4");
        answersText.Add("3");
        answersText.Add("2");
        answersText.Add("1");

        var question1 = new Question(dataController.generateUID(), "2+2", 0, answersText, "requirements", "1", "simple");
        var question2 = new Question(dataController.generateUID(), "3*1", 1, answersText, "requirements", "1", "complex");

        var questionList = new List<Question>();
        questionList.Add(question1);
        questionList.Add(question2);

        SinglePlayerInstance.questionList = questionList;
    }

    public async void SetMultiPlayerQuestions(string world, string section, string level){
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

        var question1 = new Question(dataController.generateUID(), "2+2", 0, answersText, "requirements", "1", "simple");
        var question2 = new Question(dataController.generateUID(), "3*1", 1, answersText, "requirements", "1", "complex");

        var questionList = new List<Question>();
        questionList.Add(question1);
        questionList.Add(question2); 

        MultiPlayerInstance.questionList = questionList;
        var stat1 = new Stat(dataController.generateUID(), dataController.generateUID(), dataController.generateUID(), "meowmeow", 15, true, 2, true);
        var stat2 = new Stat(dataController.generateUID(), dataController.generateUID(), dataController.generateUID(), "meowmeow", 20, true, 2, true);

        var opponentStatList = new List<Stat>();
        opponentStatList.Add(stat1);
        opponentStatList.Add(stat2);

        MultiPlayerInstance.opponentStatList = opponentStatList;
    }



    public void StartGameButtonClicked() {
        // maybe can show loading animation
        string gameType = PlayerPrefs.GetString("gameTypeSelected", "Nil");
        string world = PlayerPrefs.GetString("worldSelected", "Nil");
        string section = PlayerPrefs.GetString("sectionSelected", "Nil");
        string level = PlayerPrefs.GetString("levelSelected", "Nil");

        if (gameType == "Single") {
            SinglePlayerInstance.sldcWorld = world;
            SinglePlayerInstance.specificSection = section;
            SinglePlayerInstance.difficultyLevel = level;

            SetSinglePlayerQuestions(world, section, level);
            SceneManager.LoadScene("SinglePlayerGameUI");
        }

        else if (gameType == "Multi") {
            MultiPlayerInstance.sldcWorld = world;
            MultiPlayerInstance.specificSection = section;
            MultiPlayerInstance.difficultyLevel = level;
             
            SetMultiPlayerQuestions(world, section, level);
            SceneManager.LoadScene("MultiPlayerGameUI");
        }

        else {
            Debug.Log("Error!");
        }
    }

}
