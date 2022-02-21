using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneLoader : MonoBehaviour
{
    public void LoadStudentLogin()
    {
        SceneManager.LoadScene("StudentLoginScene");
    }

    public void LoadTeacherLogin()
    {
        SceneManager.LoadScene("TeacherLoginScene");
    }
    
    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");

    }
}