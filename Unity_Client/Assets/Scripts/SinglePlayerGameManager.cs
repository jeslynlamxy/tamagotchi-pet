using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SinglePlayerGameManager : MonoBehaviour
{
    private DataManager dataController;
    private SinglePlayerRoundData SinglePlayerInstance;
    private List<Question> questionPool;
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

    // food = accuracy * level chosen
    // water = speed * level chosen
    void determineFood() {
        float percentageAccuracy = totalCorrect/totalNumberOfQuestions;
 
        if (percentageAccuracy >= 0.9f) {
            SinglePlayerInstance.rewardedFood = 10 * difficulty;
        }
        else if (percentageAccuracy < 0.9f && percentageAccuracy >= 0.8f) {
            SinglePlayerInstance.rewardedFood = 9 * difficulty;
        }
        else if (percentageAccuracy < 0.8f && percentageAccuracy >= 0.7f) {
            SinglePlayerInstance.rewardedFood = 8 * difficulty;
        }
        else if (percentageAccuracy < 0.7f && percentageAccuracy >= 0.6f) {
            SinglePlayerInstance.rewardedFood = 7 * difficulty;
        }
        else if (percentageAccuracy < 0.6f && percentageAccuracy >= 0.5f) {
            SinglePlayerInstance.rewardedFood = 6 * difficulty;
        }
        else if (percentageAccuracy < 0.5f && percentageAccuracy >= 0.4f) {
            SinglePlayerInstance.rewardedFood = 5 * difficulty;
        }
        else if (percentageAccuracy < 0.4f && percentageAccuracy >= 0.3f) {
            SinglePlayerInstance.rewardedFood = 4 * difficulty;
        }
        else if (percentageAccuracy < 0.3f && percentageAccuracy >= 0.2f) {
            SinglePlayerInstance.rewardedFood = 3 * difficulty;
        }
        else if (percentageAccuracy < 0.2f && percentageAccuracy >= 0.1f) {
            SinglePlayerInstance.rewardedFood = 2 * difficulty;
        }
        else if (percentageAccuracy < 0.1f && percentageAccuracy >= 0f) {
            SinglePlayerInstance.rewardedFood = 1 * difficulty;
        }
        else {
            SinglePlayerInstance.rewardedFood = 0;
        }
    }
    void determineWater() {
        float baseLine = totalNumberOfQuestions * startingTime;
        float percentageSpeed = playerScore/baseLine;
        if (percentageSpeed >= 0.9f) {
            SinglePlayerInstance.rewardedWater = 10 * difficulty;
        }
        else if (percentageSpeed < 0.9f && percentageSpeed >= 0.8f) {
            SinglePlayerInstance.rewardedWater = 9 * difficulty;
        }
        else if (percentageSpeed < 0.8f && percentageSpeed >= 0.7f) {
            SinglePlayerInstance.rewardedWater = 8 * difficulty;
        }
        else if (percentageSpeed < 0.7f && percentageSpeed >= 0.6f) {
            SinglePlayerInstance.rewardedWater = 7 * difficulty;
        }
        else if (percentageSpeed < 0.6f && percentageSpeed >= 0.5f) {
            SinglePlayerInstance.rewardedWater = 6 * difficulty;
        }
        else if (percentageSpeed < 0.5f && percentageSpeed >= 0.4f) {
            SinglePlayerInstance.rewardedWater = 5 * difficulty;
        }
        else if (percentageSpeed < 0.4f && percentageSpeed >= 0.3f) {
            SinglePlayerInstance.rewardedWater = 4 * difficulty;
        }
        else if (percentageSpeed < 0.3f && percentageSpeed >= 0.2f) {
            SinglePlayerInstance.rewardedWater = 3 * difficulty;
        }
        else if (percentageSpeed < 0.2f && percentageSpeed >= 0.1f) {
            SinglePlayerInstance.rewardedWater = 2 * difficulty;
        }
        else if (percentageSpeed < 0.1f && percentageSpeed >= 0f) {
            SinglePlayerInstance.rewardedWater = 1 * difficulty;
        }
        else {
            SinglePlayerInstance.rewardedWater = 0;
        }
    }
    void Start()
    {
        dataController = FindObjectOfType<DataManager> ();
        SinglePlayerInstance = dataController.GetSinglePlayerInstance();
        Debug.Log(SinglePlayerInstance.statList);

        if (SinglePlayerInstance.difficultyLevel == "1") {
            difficulty = 1;
        }
        else if (SinglePlayerInstance.difficultyLevel == "2") {
            difficulty = 2;
        }
        else if (SinglePlayerInstance.difficultyLevel == "3") {
            difficulty = 3;
        }
        else if (SinglePlayerInstance.difficultyLevel == "4") {
            difficulty = 4;
        }

        questionPool = SinglePlayerInstance.questionList;
        
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

        quesText.text = currentQuestion.questionText;
        ansOneText.text = currentQuestion.answersText[0];
        ansTwoText.text = currentQuestion.answersText[1];
        ansThreeText.text = currentQuestion.answersText[2];
        ansFourText.text = currentQuestion.answersText[3];
    }
    public void addScore() { // correct
        SinglePlayerInstance.statList.Add(1, currentQuestion.questionId, (int)System.Math.Round(currentTime), true);
        playerScore = playerScore + (int)System.Math.Round(currentTime);
        scoreText.text = playerScore.ToString();
        totalCorrect = totalCorrect + 1;
    }
    public void loseLife() { // wrong
        SinglePlayerInstance.statList.Add(1, currentQuestion.questionId, (int)System.Math.Round(currentTime), false);
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
        if (questionPool.Count > questionIndex + 1) {
            questionIndex++;
            SetCurrentQuestion();
        }
        else {
            EndRound();
        }
        allEnable();
    }
    public void EndRound() {
        SinglePlayerInstance.finalScore = playerScore;
        determineFood();
        determineWater();
        SceneManager.LoadScene("SinglePlayerGameCompletionUI");
    }
    public void UserSelectOne (){
        if (currentQuestion.answerIndex == 0){
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
        if (currentQuestion.answerIndex == 1){
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
        if (currentQuestion.answerIndex == 2){
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
        if (currentQuestion.answerIndex == 3){
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