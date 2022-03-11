using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectAndLoadingManager : MonoBehaviour
{
    private DataManager dataController;
    private SinglePlayerRoundData SinglePlayerInstance;
    void Start()
    {
        dataController = FindObjectOfType<DataManager> ();
        SinglePlayerInstance = dataController.GetSinglePlayerInstance();
    }
    
    private List<string> tamagotchiList = new List<string>
            {"a", "b", "c"};
    private int currentPointer = 0;

    int mod(int a, int n) {
        return ((a%n)+n) % n;
    }

    public void LoadCharacterInPanel(int currentPointer) {
        int tamagotchiIndex = mod(currentPointer, tamagotchiList.Count);
        // get tamagotchi and display in screen
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
        if (level == "1") {
            // get 8 simple questions
            // get 2 complex questions
        }
        else if (level == "2") {
            // get 6 simple questions
            // get 4 complex questions
        }
        else if (level == "3") {
            // get 4 simple questions
            // get 6 complex questions
        }
        else if (level == "4") {
            // get 2 simple questions
            // get 8 complex questions
        }
        
        // sample only, need to replace with backend
        var answersText = new List<string>();
        answersText.Add("4");
        answersText.Add("3");
        answersText.Add("2");
        answersText.Add("1");

        var question1 = new Question(1, "2+2", 0, answersText, "requirements", "1", "simple");
        var question2 = new Question(2, "4-1", 1, answersText, "requirements", "1", "complex");

        var questionList = new List<Question>();
        questionList.Add(question1);
        questionList.Add(question2);

        SinglePlayerInstance.questionList = questionList;
    }

    public void StartGameButtonClicked() {
        // maybe can show loading animation
        string gameType = PlayerPrefs.GetString("gameTypeSelected", "Nil");

        if (gameType == "Single") {
            string world = PlayerPrefs.GetString("worldSelected", "Nil");
            string section = PlayerPrefs.GetString("sectionSelected", "Nil");
            string level = PlayerPrefs.GetString("levelSelected", "Nil");

            SinglePlayerInstance.sldcWorld = world;
            SinglePlayerInstance.specificSection = section;
            SinglePlayerInstance.difficultyLevel = level;

            SetSinglePlayerQuestions(world, section, level);
            SceneManager.LoadScene("SinglePlayerGameUI");
        }

        else if (gameType == "Multi") {
            SceneManager.LoadScene("MultiPlayerGameUI");
        }

        else {
            Debug.Log("Error!");
        }
    }

}
