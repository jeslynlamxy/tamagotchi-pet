using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
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
    
    void Start() {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0){
            unansweredQuestions = questions.ToList<Question>();
            Debug.Log("NextLevel");
        }
        SetCurrentQuestion();
        // Debug.Log(currentQuestion.QuestionText + " = " + currentQuestion.AnswerIndex);

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
            Debug.Log("good");
        }
        else {
            Debug.Log("noob");
        }
        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectTwo (){
        if (currentQuestion.AnswerIndex == 1){
            Debug.Log("good");
        }
        else {
            Debug.Log("noob");
        }
        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectThree (){
        if (currentQuestion.AnswerIndex == 2){
            Debug.Log("good");
        }
        else {
            Debug.Log("noob");
        }
        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectFour (){
        if (currentQuestion.AnswerIndex == 3){
            Debug.Log("good");
        }
        else {
            Debug.Log("noob");
        }
        StartCoroutine(TransitionToNextQuestion());
    }
}
