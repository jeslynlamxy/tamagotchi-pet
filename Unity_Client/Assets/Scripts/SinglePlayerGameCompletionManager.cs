using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SinglePlayerGameCompletionManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText, foodText, waterText;
     private DataManager dataController;
    private RoundData currentRoundData;

    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataManager> ();
        currentRoundData = dataController.GetCurrentRoundData();
        int score = currentRoundData.finalScore;
        int food = currentRoundData.rewardedFood;
        int water = currentRoundData.rewardedWater;
        scoreText.text = score.ToString();
        foodText.text = food.ToString();
        waterText.text = water.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
