using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StudentWelcomeManager : MonoBehaviour
{
    public Text usernameLabel;

    void Start()
    {
        UpdateStudentUsername();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SingleMultiPlayerSelectionUI");
    }

    public void UpdateStudentUsername()
    {
        var studentUsername = PlayerPrefs.GetString("studentUsername");
        Debug.Log(studentUsername);
        var label = "hello, " + studentUsername + "!";
        usernameLabel.text = label;
    }

}
