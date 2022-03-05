using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StudentWelcomeManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SingleMultiPlayerSelectionUI");
    }

}
