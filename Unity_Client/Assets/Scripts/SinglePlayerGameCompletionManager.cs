using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using TMPro;

public class SinglePlayerGameCompletionManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText, foodText, waterText;
     private DataManager dataController;
    private SinglePlayerRoundData currentRoundData;
    private SceneLoaderManager scene;
    

    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataManager> ();
        currentRoundData = dataController.GetSinglePlayerInstance();
        int score = currentRoundData.finalScore;
        int food = currentRoundData.rewardedFood;
        int water = currentRoundData.rewardedWater;
        scoreText.text = score.ToString();
        foodText.text = food.ToString();
        waterText.text = water.ToString();
    }

    public void LeaderBoard() {
        scene = new SceneLoaderManager();
        scene.LoadLeaderboardUI();
    }

    public void MainMenu() {
        scene = new SceneLoaderManager();
        scene.LoadStudentWelcomeUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
