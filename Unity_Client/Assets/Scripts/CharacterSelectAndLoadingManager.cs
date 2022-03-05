using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectAndLoadingManager : MonoBehaviour
{
    // get available characters Question[] questions
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

    public void StartGameButtonClicked() {
        string gameType = PlayerPrefs.GetString("gameTypeSelected", "Nil");

        if (gameType == "Single") {
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
