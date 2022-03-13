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
        if (level == "1") {
            // get 8 simple questions from server
            // get 2 complex questions from server
        }
        else if (level == "2") {
            // get 6 simple questions from server
            // get 4 complex questions from server
        }
        else if (level == "3") {
            // get 4 simple questions from server
            // get 6 complex questions from server
        }
        else if (level == "4") {
            // get 2 simple questions from server
            // get 8 complex questions from server
        }
        
        // sample only, need to replace with backend stuffs above
        var answersText = new List<string>();
        answersText.Add("4");
        answersText.Add("3");
        answersText.Add("2");
        answersText.Add("1");

        var question1 = new Question(1, "2+2", 0, answersText, "requirements", "1", "simple");
        var question2 = new Question(2, "3*1", 1, answersText, "requirements", "1", "complex");

        var questionList = new List<Question>();
        questionList.Add(question1);
        questionList.Add(question2);

        SinglePlayerInstance.questionList = questionList;
    }

    public void SetMultiPlayerQuestions(string world, string section, string level){
        // considering the world section level do the item below
        // get single player game in data base with same world section level
        // get the stat data as well

        // sample only, need to replace with backend stuffs above
        var answersText = new List<string>();
        answersText.Add("4");
        answersText.Add("3");
        answersText.Add("2");
        answersText.Add("1");

        // Question(int questionId, string questionText, int answerIndex, List<string> answersText, string worldTopic, string specificSection, string questionStandard)
        var question1 = new Question(1, "2+2", 0, answersText, "requirements", "1", "simple");
        var question2 = new Question(2, "3*1", 1, answersText, "requirements", "1", "complex");

        var questionList = new List<Question>();
        questionList.Add(question1);
        questionList.Add(question2); 

        MultiPlayerInstance.questionList = questionList;

        // public Stat(int statId, int roundId, int questionId, string studentUsername, int timing, int currentHealth, bool skillLeft, bool isCorrect)
        var stat1 = new Stat(1, 1, 1, "meowmeow", 15, 2, true);
        var stat2 = new Stat(2, 1, 2, "meowmeow", 20, 2, true);

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
