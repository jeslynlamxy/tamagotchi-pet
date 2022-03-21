using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using Newtonsoft.Json;

public class MultiPlayerGameCompletionManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText, foodText, waterText, winText, victoryOrDefeatText;
    private DataManager dataController;
    private MultiPlayerRoundData currentRoundData;
    public string username;
    public Student student;
    private HttpManager http;
    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataManager>();
        currentRoundData = dataController.GetMultiPlayerInstance();
        username = dataController.username;

        int food = currentRoundData.rewardedFood;
        int water = currentRoundData.rewardedWater;
        int win = currentRoundData.winPoint;
        int playerScore = currentRoundData.finalScore;
        int opponentScore = currentRoundData.opponentStatList.Sum(item => item.timing);

        scoreText.text = playerScore.ToString();
        winText.text = win.ToString();
        foodText.text = food.ToString();
        waterText.text = water.ToString();

        if (playerScore >= opponentScore)
        {
            victoryOrDefeatText.text = "victory";
        }
        else
        {
            victoryOrDefeatText.text = "defeat";
        }
        // update user data in server
        GetStudentData();
        student.currentFood += food;
        student.currentWater += water;
        student.highestScore += playerScore;
        UpdateStudentData();
        AddMultiPlayerRoundData();
    }
    public void GetStudentData()
    {
        http = new HttpManager();
        var url = "http://172.21.148.165/get_userData?username=" + username; // add query parameter using username
        var responseStr = http.Post(url, "");
        student = JsonConvert.DeserializeObject<Student>(responseStr);
    }

    public void UpdateStudentData()
    {
        var url = "http://172.21.148.165/update_userData?username=" + username; // add query parameter using username
        var responseStr = http.Post(url, student);
        Debug.Log(responseStr);
    }
    public void AddMultiPlayerRoundData()
    {
        var url = "http://172.21.148.165/add_MultiPlayerRoundData";
        var responseStr = http.Post(url, currentRoundData);
        Debug.Log(responseStr);
    }

    public void BackToMenuButtonClick()
    {
        SceneManager.LoadScene("StudentWelcomeUI");
    }
    public void LeaderboardButtonClick()
    {
        //
    }
    public void SocialsButtonClick()
    {
        //
    }
}
