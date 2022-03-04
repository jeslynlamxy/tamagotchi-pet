using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;


public class QuestionManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestions;
    private Question currentQuestion;

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
    private float timeBetweenQuestion = 1f;

    float currentTime = 0f;
    float startingTime = 30f;

    [SerializeField]
    public Text countdownText;

    void Start() {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0){
            unansweredQuestions = questions.ToList<Question>();
            Debug.Log("NextLevel");
        }
        SetCurrentQuestion();
        currentTime = startingTime;
    }

    void Update() {
        currentTime -= 1 *  Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime < 10f) {
            countdownText.color = Color.red;
        }

        if (currentTime <= 0) {
            currentTime = 0;
            StartCoroutine(TransitionToNextQuestion());
        }
    }


    void SetCurrentQuestion(){
        int randomQuestionIndex = Random.Range (0,unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        quesText.text = currentQuestion.QuestionText;
        ansOneText.text = currentQuestion.AnswersText[0];
        ansTwoText.text = currentQuestion.AnswersText[1];
        ansThreeText.text = currentQuestion.AnswersText[2];
        ansFourText.text = currentQuestion.AnswersText[3];

    }

    IEnumerator TransitionToNextQuestion(){
        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(timeBetweenQuestion);
        // load this scene agn
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UserSelectOne (){
        if (currentQuestion.AnswerIndex == 0){
            ansOneText.color = Color.green;
        }
        else {
            ansOneText.color = Color.red;
        }
        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectTwo (){
        if (currentQuestion.AnswerIndex == 1){
            ansTwoText.color = Color.green;
        }
        else {
            ansTwoText.color = Color.red;
        }
        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectThree (){
        if (currentQuestion.AnswerIndex == 2){
            ansThreeText.color = Color.green;
        }
        else {
            ansThreeText.color = Color.red;
        }
        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectFour (){
        if (currentQuestion.AnswerIndex == 3){
            ansFourText.color = Color.green;
        }
        else {
            ansFourText.color = Color.red;
        }
        StartCoroutine(TransitionToNextQuestion());
    }
}

