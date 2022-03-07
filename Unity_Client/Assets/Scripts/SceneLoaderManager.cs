using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneLoaderManager : MonoBehaviour
{
    public void LoadPrevScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadMainPageUI()
    {
        SceneManager.LoadScene("MainPageUI");
    }

    public void LoadStudentLoginUI()
    {
        SceneManager.LoadScene("StudentLoginUI");
    }
    public void LoadTeacherLoginUI()
    {
        SceneManager.LoadScene("TeacherLoginUI");
    }

    public void LoadStudentWelcomeUI()
    {
        SceneManager.LoadScene("StudentWelcomeUI");
    }
    public void LoadTeacherWelcomeUI()
    {
        SceneManager.LoadScene("TeacherWelcomeUI");
    }
    public void LoadVirtualVillageUI()
    {
        SceneManager.LoadScene("VirtualVillageUI");
    }
    public void LoadChangeSkinUI()
    {
        SceneManager.LoadScene("ChangeSkinUI");
    }
    public void LoadSingleMultiPlayerSelectionUI()
    {
        SceneManager.LoadScene("SingleMultiPlayerSelectionUI");
    }
    public void LoadWorldAndDifficultySelectionUI()
    {
        SceneManager.LoadScene("WorldAndDifficultySelectionUI");
    }
    public void LoadCharacterSelectionUI()
    {
        SceneManager.LoadScene("CharacterSelectionUI");
    }

    public void LoadGameUI()
    {
        var pref = PlayerPrefs.GetString("gameTypeSelected");
        if (pref == "Single")
        {
            SceneManager.LoadScene("SinglePlayerGameUI");
        }
        else if (pref == "Multi")
        {
            SceneManager.LoadScene("MultiPlayerGameUI");
        }

    }

    public void LoadGameCompletionUI()
    {
        var pref = PlayerPrefs.GetString("gameTypeSelected");
        if (pref == "Single")
        {
            SceneManager.LoadScene("SinglePlayerGameCompletionUI");
        }
        else if (pref == "Multi")
        {
            SceneManager.LoadScene("MultiPlayerGameCompletionUI");
        }

    }
    public void LoadSinglePlayerGameCompletionUI()
    {
        SceneManager.LoadScene("SinglePlayerGameCompletionUI");
    }
    public void LoadLeaderboardUI()
    {
        SceneManager.LoadScene("LeaderboardUI");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");

    }
}