using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MultiPlayerGameCompletionManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText, foodText, waterText, winText;
     private DataManager dataController;
    private MultiPlayerRoundData currentRoundData;

    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataManager> ();
        currentRoundData = dataController.GetMultiPlayerInstance();
        int score = currentRoundData.finalScore;
        int food = currentRoundData.rewardedFood;
        int water = currentRoundData.rewardedWater;
        int win = currentRoundData.winPoint;
        scoreText.text = score.ToString();
        winText.text = win.ToString();
        foodText.text = food.ToString();
        waterText.text = water.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenuButtonClick() {
        SceneManager.LoadScene("StudentWelcomeUI");
    }
    public void LeaderboardButtonClick() {
        //
    }
    public void SocialsButtonClick() {
        //
    }
}
