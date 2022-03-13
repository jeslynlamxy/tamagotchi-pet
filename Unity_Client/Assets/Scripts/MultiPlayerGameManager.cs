using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MultiPlayerGameManager : MonoBehaviour
{
 private DataManager dataController;
    private MultiPlayerRoundData multiPlayerInstance;
    private List<Question> questionPool;
    private List<Stat> opponentStatPool;
    private Question currentQuestion;
    private float timePerQuestion;
    private int questionIndex, playerScore, playerLife, totalNumberOfQuestions, totalCorrect, winPoint, currentTiming, opponentTiming;
    private bool skillLeft;
    private string skillExplained; // "add 5 seconds", "recover 1 life"
    float currentTime = 0f;
    float startingTime = 20f;
    private int timeBetweenQuestion = 2000;
    public Button ansOne, ansTwo, ansThree, ansFour, usedSkill;
    public int difficulty;

    [SerializeField]
    private TextMeshProUGUI quesText, ansOneText, ansTwoText, ansThreeText, ansFourText;

    [SerializeField]
    public Text countdownText, scoreText, lifeText, winText, skillLeftText, skillExplainText;
    
    void Start()
    {

        dataController = FindObjectOfType<DataManager> ();
        multiPlayerInstance = dataController.GetMultiPlayerInstance();
        multiPlayerInstance.playerStatList = new List<Stat>();

        if (multiPlayerInstance.difficultyLevel == "1") {
            difficulty = 1;
        }
        else if (multiPlayerInstance.difficultyLevel == "2") {
            difficulty = 2;
        }
        else if (multiPlayerInstance.difficultyLevel == "3") {
            difficulty = 3;
        }
        else if (multiPlayerInstance.difficultyLevel == "4") {
            difficulty = 4;
        }

        questionPool = multiPlayerInstance.questionList;
        opponentStatPool = multiPlayerInstance.opponentStatList;
        
        playerScore = 0;
        playerLife = 3;
        questionIndex = 0;
        winPoint = 0;

        skillLeft = true;
        skillExplained = "add 5 seconds"; // get from server
        skillLeftText.text = "1";
        skillExplainText.text = skillExplained;

        usedSkill.interactable = true;

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
     public void whenSkillButtonPressed () {
        if (skillLeft == true) {
            skillLeft = false;
            skillLeftText.text = "0";
            if (skillExplained == "add 5 seconds") {
            currentTime = currentTime + 5f;
            }
            else if (skillExplained == "recover 1 life") {
                playerLife = playerLife + 1;
                lifeText.text = playerLife.ToString();
            }
            usedSkill.interactable = false;
        }
    }
    // food = accuracy * level chosen + bonus win point
    // water = speed * level chosen + bonus win point
    void determineFood() {
        float percentageAccuracy = totalCorrect/totalNumberOfQuestions;
 
        if (percentageAccuracy >= 0.9f) {
            multiPlayerInstance.rewardedFood = 10 * difficulty + winPoint;
        }
        else if (percentageAccuracy < 0.9f && percentageAccuracy >= 0.8f) {
            multiPlayerInstance.rewardedFood = 9 * difficulty + winPoint;
        }
        else if (percentageAccuracy < 0.8f && percentageAccuracy >= 0.7f) {
            multiPlayerInstance.rewardedFood = 8 * difficulty + winPoint;
        }
        else if (percentageAccuracy < 0.7f && percentageAccuracy >= 0.6f) {
            multiPlayerInstance.rewardedFood = 7 * difficulty + winPoint;
        }
        else if (percentageAccuracy < 0.6f && percentageAccuracy >= 0.5f) {
            multiPlayerInstance.rewardedFood = 6 * difficulty + winPoint;
        }
        else if (percentageAccuracy < 0.5f && percentageAccuracy >= 0.4f) {
            multiPlayerInstance.rewardedFood = 5 * difficulty + winPoint;
        }
        else if (percentageAccuracy < 0.4f && percentageAccuracy >= 0.3f) {
            multiPlayerInstance.rewardedFood = 4 * difficulty + winPoint;
        }
        else if (percentageAccuracy < 0.3f && percentageAccuracy >= 0.2f) {
            multiPlayerInstance.rewardedFood = 3 * difficulty + winPoint;
        }
        else if (percentageAccuracy < 0.2f && percentageAccuracy >= 0.1f) {
            multiPlayerInstance.rewardedFood = 2 * difficulty + winPoint;
        }
        else if (percentageAccuracy < 0.1f && percentageAccuracy >= 0f) {
            multiPlayerInstance.rewardedFood = 1 * difficulty + winPoint;
        }
        else {
            multiPlayerInstance.rewardedFood = 0;
        }
    }
    void determineWater() {
        float baseLine = totalNumberOfQuestions * startingTime;
        float percentageSpeed = playerScore/baseLine;
        if (percentageSpeed >= 0.9f) {
            multiPlayerInstance.rewardedWater = 10 * difficulty + winPoint;
        }
        else if (percentageSpeed < 0.9f && percentageSpeed >= 0.8f) {
            multiPlayerInstance.rewardedWater = 9 * difficulty + winPoint;
        }
        else if (percentageSpeed < 0.8f && percentageSpeed >= 0.7f) {
            multiPlayerInstance.rewardedWater = 8 * difficulty + winPoint;
        }
        else if (percentageSpeed < 0.7f && percentageSpeed >= 0.6f) {
            multiPlayerInstance.rewardedWater = 7 * difficulty + winPoint;
        }
        else if (percentageSpeed < 0.6f && percentageSpeed >= 0.5f) {
            multiPlayerInstance.rewardedWater = 6 * difficulty + winPoint;
        }
        else if (percentageSpeed < 0.5f && percentageSpeed >= 0.4f) {
            multiPlayerInstance.rewardedWater = 5 * difficulty + winPoint;
        }
        else if (percentageSpeed < 0.4f && percentageSpeed >= 0.3f) {
            multiPlayerInstance.rewardedWater = 4 * difficulty + winPoint;
        }
        else if (percentageSpeed < 0.3f && percentageSpeed >= 0.2f) {
            multiPlayerInstance.rewardedWater = 3 * difficulty + winPoint;
        }
        else if (percentageSpeed < 0.2f && percentageSpeed >= 0.1f) {
            multiPlayerInstance.rewardedWater = 2 * difficulty + winPoint;
        }
        else if (percentageSpeed < 0.1f && percentageSpeed >= 0f) {
            multiPlayerInstance.rewardedWater = 1 * difficulty + winPoint;
        }
        else {
            multiPlayerInstance.rewardedWater = 0;
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
        multiPlayerInstance.finalScore = playerScore;
        multiPlayerInstance.winPoint = winPoint;
        determineFood();
        determineWater();
        SceneManager.LoadScene("MultiPlayerGameCompletionUI");
    }
    public int getOpponentTiming(int questionId) {
        var listItem = opponentStatPool.FirstOrDefault(x => x.questionId == questionId);
        if (listItem != null)
        {
            return listItem.timing;
        }
        else
        {
            return 0;
        }
    }
    public void compareScore() {
        currentTiming = (int)System.Math.Round(currentTime);
        opponentTiming = getOpponentTiming(currentQuestion.questionId);
        if (currentTiming > opponentTiming) {
            winPoint = winPoint + 1;
            winText.text = winPoint.ToString();
        }
        playerScore = playerScore + (int)System.Math.Round(currentTime);
        scoreText.text = playerScore.ToString();
        totalCorrect = totalCorrect + 1;
        // public Stat(int statId, int roundId, int questionId, string studentUsername, int timing, int currentHealth, bool isSkillLeft)
        var newStat = new Stat(1, 1, currentQuestion.questionId, "meowmeow", (int)System.Math.Round(currentTime), playerLife, skillLeft);
        multiPlayerInstance.playerStatList.Add(newStat);
    }
    public void loseLife() {
        playerLife = playerLife - 1;
        lifeText.text = playerLife.ToString();
        if (playerLife <= 0) {
            lifeText.color = Color.red;
            EndRound();
        }
        // public Stat(int statId, int roundId, int questionId, string studentUsername, int timing, int currentHealth, bool isSkillLeft)
        var newStat = new Stat(1, 1, currentQuestion.questionId, "meowmeow", 0, playerLife, skillLeft);
        multiPlayerInstance.playerStatList.Add(newStat);
    }
    public void UserSelectOne (){
        if (currentQuestion.answerIndex == 0){
            ansOneText.color = Color.green;
            compareScore();
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
            compareScore();
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
            compareScore();
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
            compareScore();
        }
        else {
            ansFourText.color = Color.red;
            loseLife();
        }
        ManageNext();
    }
    public void allDisable(){
        ansOne.interactable = false;
        ansTwo.interactable = false;
        ansThree.interactable = false;
        ansFour.interactable = false;
    }
    public void allEnable(){
        ansOne.interactable = true;
        ansTwo.interactable = true;
        ansThree.interactable = true;
        ansFour.interactable = true;
    }
}
