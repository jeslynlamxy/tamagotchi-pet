using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
public class SinglePlayerGameManager : MonoBehaviour
{
    private DataManager dataController;
    private RoundData currentRoundData;
    private Question[] questionPool;
    private Question currentQuestion;
    private bool isGameActive;
    private float timePerQuestion;
    private int questionIndex;
    private int playerScore;
    private int playerLife;

    [SerializeField]
    private Text quesText;

    [SerializeField]
    private Text ansOneText;

    [SerializeField]
    private Text ansTwoText;

    [SerializeField]
    private Text ansThreeText;

    [SerializeField]
    private Text ansFourText;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text lifeText;

    float currentTime = 0f;
    float startingTime = 15f;

    [SerializeField]
    private float timeBetweenQuestion = 2.0f;

    [SerializeField]
    public Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataManager> ();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        
        playerScore = 0;
        playerLife = 3;
        questionIndex = 0;
        isGameActive = true;
        SetCurrentQuestion();
        
    }

    void Update() {
        currentTime -= 1 *  Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime < 10f) {
            countdownText.color = Color.red;
        }

        if (currentTime <= 0) {
            currentTime = 0;
            loseLife();
            ManageNext();
        }
    }

    void SetCurrentQuestion(){
        // set time
        currentTime = startingTime;
        countdownText.color = Color.black;
        scoreText.text = playerScore.ToString();
        lifeText.text = playerLife.ToString();

        currentQuestion = questionPool[questionIndex];

        ansOneText.color = Color.black;
        ansTwoText.color = Color.black;
        ansThreeText.color = Color.black;
        ansFourText.color = Color.black;

        quesText.text = currentQuestion.QuestionText;
        ansOneText.text = currentQuestion.AnswersText[0];
        ansTwoText.text = currentQuestion.AnswersText[1];
        ansThreeText.text = currentQuestion.AnswersText[2];
        ansFourText.text = currentQuestion.AnswersText[3];

    }

    public void addScore() {
        playerScore = playerScore + (int)System.Math.Round(currentTime);
        scoreText.text = playerScore.ToString();
    }

    public void loseLife() {
        playerLife = playerLife - 1;
        lifeText.text = playerLife.ToString();
        if (playerLife <= 0) {
            lifeText.color = Color.red;
            EndRound();
        }
    }

    public void ManageNext() {
        if (questionPool.Length > questionIndex + 1) {
            questionIndex++;
            SetCurrentQuestion();
        }
        else {
            Invoke("EndRound", timeBetweenQuestion);
        }
    }

    public void EndRound() {
        isGameActive = false;
        // set stats in round data perhaps
        SceneManager.LoadScene("SinglePlayerGameCompletionUI");
    }

    public void UserSelectOne (){
        if (currentQuestion.AnswerIndex == 0){
            ansOneText.color = Color.green;
            Invoke("addScore", timeBetweenQuestion);
        }
        else {
            ansOneText.color = Color.red;
            Invoke("loseLife", timeBetweenQuestion);
        }
        ManageNext();
    }

    public void UserSelectTwo (){
        if (currentQuestion.AnswerIndex == 1){
            ansTwoText.color = Color.green;
            Invoke("addScore", timeBetweenQuestion);
        }
        else {
            ansTwoText.color = Color.red;
            Invoke("loseLife", timeBetweenQuestion);
        }
        ManageNext();
    }

    public void UserSelectThree (){
        if (currentQuestion.AnswerIndex == 2){
            ansThreeText.color = Color.green;
            Invoke("addScore", timeBetweenQuestion);
        }
        else {
            ansThreeText.color = Color.red;
            Invoke("loseLife", timeBetweenQuestion);
        }
        ManageNext();
    }

    public void UserSelectFour (){
        if (currentQuestion.AnswerIndex == 3){
            ansFourText.color = Color.green;
            Invoke("addScore", timeBetweenQuestion);
        }
        else {
            ansFourText.color = Color.red;
            Invoke("loseLife", timeBetweenQuestion);
        }
        ManageNext();
    }
}
