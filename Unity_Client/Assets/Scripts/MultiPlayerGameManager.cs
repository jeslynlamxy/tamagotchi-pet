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
    private int questionIndex, playerScore, playerLife, totalNumberOfQuestions, totalCorrect, winPoint, currentTiming, opponentTiming, skillLeft;
    private string skillExplained = "add 5 seconds";
    float currentTime = 0f;
    float startingTime = 20f;
    private int timeBetweenQuestion = 2000;
    public Button ansOne, ansTwo, ansThree, ansFour;
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
        // scoreText.text = playerScore.ToString();
        // lifeText.text = playerLife.ToString();

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
        // determineFood();
        // determineWater();
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
    // Stat(int statId, int roundId, int questionId, int timing, int currentHealth, bool isCorrect)
    public void compareScore() {
        currentTiming = (int)System.Math.Round(currentTime);
        opponentTiming = getOpponentTiming(currentQuestion.questionId);
        if (currentTiming > opponentTiming) {
            winPoint = winPoint + 1;
            winText.text = winPoint.ToString();
        }
        playerScore = playerScore + (int)System.Math.Round(currentTime);
        // scoreText.text = playerScore.ToString();
        totalCorrect = totalCorrect + 1;
        // Stat(int statId, int roundId, int questionId, int timing, int currentHealth, bool isCorrect)
        var newStat = new Stat(1, 1, currentQuestion.questionId, (int)System.Math.Round(currentTime), playerLife, true);
        multiPlayerInstance.playerStatList.Add(newStat);
    }
    public void loseLife() {
        playerLife = playerLife - 1;
        // lifeText.text = playerLife.ToString();
        if (playerLife <= 0) {
            lifeText.color = Color.red;
            EndRound();
        }
        // Stat(int statId, int roundId, int questionId, int timing, int currentHealth, bool isCorrect)
        var newStat = new Stat(1, 1, currentQuestion.questionId, (int)System.Math.Round(currentTime), playerLife, true);
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
