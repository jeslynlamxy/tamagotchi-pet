using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ViewStatsManager : MonoBehaviour
{
    private SceneLoaderManager scene;

    void Start() {

    }

    void Update()
    {
        
    }

    public void BackButtonClick() {
        SceneManager.LoadScene("TeacherWelcomeUI");
    }

}