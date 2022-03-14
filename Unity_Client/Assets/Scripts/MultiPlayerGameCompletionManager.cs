using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class MultiPlayerGameCompletionManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText, foodText, waterText, winText, victoryOrDefeatText;
     private DataManager dataController;
    private MultiPlayerRoundData currentRoundData;
    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataManager> ();
        currentRoundData = dataController.GetMultiPlayerInstance();

        int food = currentRoundData.rewardedFood;
        int water = currentRoundData.rewardedWater;
        int win = currentRoundData.winPoint;
        int playerScore = currentRoundData.finalScore;
        int opponentScore = currentRoundData.opponentStatList.Sum(item => item.timing);

        scoreText.text = playerScore.ToString();
        winText.text = win.ToString();
        foodText.text = food.ToString();
        waterText.text = water.ToString();

        if (playerScore >= opponentScore) {
            victoryOrDefeatText.text = "victory";
        }
        else {
            victoryOrDefeatText.text = "defeat";
        }
        // update user data in server
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
