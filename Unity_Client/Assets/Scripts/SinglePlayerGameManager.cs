using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SinglePlayerGameManager : MonoBehaviour
{
    private DataManager dataController;
    private RoundData currentRoundData;
    private Question[] questionPool;
    private Question currentQuestion;
    private float timePerQuestion;
    private int questionIndex, playerScore, playerLife, totalNumberOfQuestions, totalCorrect;
    float currentTime = 0f;
    float startingTime = 20f;
    private int timeBetweenQuestion = 2000;
    [SerializeField]
    private Text quesText, ansOneText, ansTwoText, ansThreeText, ansFourText, scoreText, lifeText;
    [SerializeField]
    public Text countdownText;
    public Button AnsOne, AnsTwo, AnsThree, AnsFour;
    public int difficulty;
    // add get question difficultly function
    void getDifficulty() {
        Debug.Log("lol");
        // base = 0;
        // for question in list of questions:
        //      difficultyLevel = getQnsDifficulty;
        //      if is easy base + 1
        //      if is medium base + 2
        //      if is hard base + 3
        // difficulty = 
    }

    // food = accuracy
    // water = speed
    void determineFood() {
        float percentageAccuracy = totalCorrect/totalNumberOfQuestions;
 
        if (percentageAccuracy >= 0.9f) {
            currentRoundData.rewardedFood = 10 * difficulty;
        }
        else if (percentageAccuracy < 0.9f && percentageAccuracy >= 0.8f) {
            currentRoundData.rewardedFood = 9 * difficulty;
        }
        else if (percentageAccuracy < 0.8f && percentageAccuracy >= 0.7f) {
            currentRoundData.rewardedFood = 8 * difficulty;
        }
        else if (percentageAccuracy < 0.7f && percentageAccuracy >= 0.6f) {
            currentRoundData.rewardedFood = 7 * difficulty;
        }
        else if (percentageAccuracy < 0.6f && percentageAccuracy >= 0.5f) {
            currentRoundData.rewardedFood = 6 * difficulty;
        }
        else if (percentageAccuracy < 0.5f && percentageAccuracy >= 0.4f) {
            currentRoundData.rewardedFood = 5 * difficulty;
        }
        else if (percentageAccuracy < 0.4f && percentageAccuracy >= 0.3f) {
            currentRoundData.rewardedFood = 4 * difficulty;
        }
        else if (percentageAccuracy < 0.3f && percentageAccuracy >= 0.2f) {
            currentRoundData.rewardedFood = 3 * difficulty;
        }
        else if (percentageAccuracy < 0.2f && percentageAccuracy >= 0.1f) {
            currentRoundData.rewardedFood = 2 * difficulty;
        }
        else if (percentageAccuracy < 0.1f && percentageAccuracy >= 0f) {
            currentRoundData.rewardedFood = 1 * difficulty;
        }
        else {
            currentRoundData.rewardedFood = 0;
        }
    }
    void determineWater() {
        float baseLine = totalNumberOfQuestions * startingTime;
        float percentageSpeed = playerScore/baseLine;
        if (percentageSpeed >= 0.9f) {
            currentRoundData.rewardedWater = 10;
        }
        else if (percentageSpeed < 0.9f && percentageSpeed >= 0.8f) {
            currentRoundData.rewardedWater = 9;
        }
        else if (percentageSpeed < 0.8f && percentageSpeed >= 0.7f) {
            currentRoundData.rewardedWater = 8;
        }
        else if (percentageSpeed < 0.7f && percentageSpeed >= 0.6f) {
            currentRoundData.rewardedWater = 7;
        }
        else if (percentageSpeed < 0.6f && percentageSpeed >= 0.5f) {
            currentRoundData.rewardedWater = 6;
        }
        else if (percentageSpeed < 0.5f && percentageSpeed >= 0.4f) {
            currentRoundData.rewardedWater = 5;
        }
        else if (percentageSpeed < 0.4f && percentageSpeed >= 0.3f) {
            currentRoundData.rewardedWater = 4;
        }
        else if (percentageSpeed < 0.3f && percentageSpeed >= 0.2f) {
            currentRoundData.rewardedWater = 3;
        }
        else if (percentageSpeed < 0.2f && percentageSpeed >= 0.1f) {
            currentRoundData.rewardedWater = 2;
        }
        else if (percentageSpeed < 0.1f && percentageSpeed >= 0f) {
            currentRoundData.rewardedWater = 1;
        }
        else {
            currentRoundData.rewardedWater = 0;
        }
    }
    void Start()
    {
        dataController = FindObjectOfType<DataManager> ();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        
        playerScore = 0;
        playerLife = 3;
        questionIndex = 0;

        totalNumberOfQuestions=0;
        totalCorrect=0;

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
        totalNumberOfQuestions = totalNumberOfQuestions + 1;
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
        totalCorrect = totalCorrect + 1;
    }
    public void loseLife() {
        playerLife = playerLife - 1;
        lifeText.text = playerLife.ToString();
        if (playerLife <= 0) {
            lifeText.color = Color.red;
            EndRound();
        }
    }
    public async void ManageNext() {
        allDisable();
        await Task.Delay(timeBetweenQuestion);
        if (questionPool.Length > questionIndex + 1) {
            questionIndex++;
            SetCurrentQuestion();
        }
        else {
            EndRound();
        }
        allEnable();
    }
    public void EndRound() {
        currentRoundData.finalScore = playerScore;
        determineFood();
        determineWater();
        SceneManager.LoadScene("SinglePlayerGameCompletionUI");
    }
    public void UserSelectOne (){
        if (currentQuestion.AnswerIndex == 0){
            ansOneText.color = Color.green;
            addScore();
        }
        else {
            ansOneText.color = Color.red;
            loseLife();
        }
        ManageNext();
    }
    public void UserSelectTwo (){
        if (currentQuestion.AnswerIndex == 1){
            ansTwoText.color = Color.green;
            addScore();
        }
        else {
            ansTwoText.color = Color.red;
            loseLife();
        }
        ManageNext();
    }
    public void UserSelectThree (){
        if (currentQuestion.AnswerIndex == 2){
            ansThreeText.color = Color.green;
            addScore();
        }
        else {
            ansThreeText.color = Color.red;
            loseLife();
        }
        ManageNext();
    }
    public void UserSelectFour (){
        if (currentQuestion.AnswerIndex == 3){
            ansFourText.color = Color.green;
            addScore();
        }
        else {
            ansFourText.color = Color.red;
            loseLife();
        }
        ManageNext();
    }
    public void allDisable(){
        AnsOne.interactable = false;
        AnsTwo.interactable = false;
        AnsThree.interactable = false;
        AnsFour.interactable = false;
    }
    public void allEnable(){
        AnsOne.interactable = true;
        AnsTwo.interactable = true;
        AnsThree.interactable = true;
        AnsFour.interactable = true;
    }
}