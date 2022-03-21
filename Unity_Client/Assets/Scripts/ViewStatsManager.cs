using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class ViewStatsManager : MonoBehaviour
{
    private HttpManager http;

    private SceneLoaderManager scene;

    private List<StudentsScoreList> studentList;

    private List<QuestionsScoreList> questionsList;

    private string currStatsPage = "students";

    private int currStudentsIndex = 0;

    private int currQuestionsIndex = 0;

    public StudentsRowUI studentrowUI;

    int MaxStats = 5; // Number of scores to be shown on one page

    void Start() {
        //currLeaderboardIndex = 0;
        // GetStudentsStatsData();
        GetQuestionsStatsData();
        // LoadStudentsStatistics(0);
    }

    public class StudentsScoreList
    {
        public StudentsScoreList(string username, int score)
        {
            this.username = username;
            this.score = score;
        }

        public string username { get; set; }
        public int score { get; set; }

    }

    public void GetStudentsStatsData()
    {
        http = new HttpManager();
        var url = "http://172.21.148.165/get_Leaderboard"; // change 
        var responseStr = http.Post(url, ""); 
        Debug.Log(responseStr);
        studentList = JsonConvert.DeserializeObject<List<StudentsScoreList>>(responseStr);
        studentList = studentList.OrderByDescending(o=>o.score).ToList();
    }

    public async void LoadStudentsStatistics(int currStudentsIndex)
    {
        if (currStudentsIndex == 0)
        {
        for (int i = 0; i < Mathf.Min(MaxStats, studentList.Count); i++)
        {
            Debug.Log(studentList[i].username);
            Debug.Log(studentList[i].score);
                //if ((studentList[i] != null ) && (studentList[i].score != 0))
                if ((studentList[i] != null ))
                {
                    var row = Instantiate(studentrowUI, transform).GetComponent<StudentsRowUI>();
                    row.gameObject.name = "Row" + (i+1).ToString();
                    // row.rank.text = (i + 1).ToString();
                    row.name.text = studentList[i].username;
                    row.score.text = studentList[i].score.ToString(); 
                }
            }
        }
        else
        {
            for (int i = 5; i < Mathf.Min(2*MaxStats, studentList.Count); i++)
            {
            Debug.Log(studentList[i].username);
            Debug.Log(studentList[i].score);
                //if ((studentList[i] != null ) && (studentList[i].score != 0))
                if ((studentList[i] != null ))
                {
                    var row = Instantiate(studentrowUI, transform).GetComponent<StudentsRowUI>();
                    row.gameObject.name = "Row" + (i+1).ToString();
                    // row.rank.text = (i + 1).ToString();
                    row.name.text = studentList[i].username;
                    row.score.text = studentList[i].score.ToString(); 
                }
            }
        }
    }

    public class QuestionsScoreList
    {
        public QuestionsScoreList(string username, int score)
        {
            this.username = username;
            this.score = score;
        }

        public string username { get; set; }
        public int score { get; set; }

    }

    public void GetQuestionsStatsData()
    {
        http = new HttpManager();
        var url = "http://172.21.148.165/get_SinglePlayerRoundData"; // change 
        var responseStr = http.Post(url, ""); 
        Debug.Log(responseStr);
        questionsList = JsonConvert.DeserializeObject<List<QuestionsScoreList>>(responseStr);
        questionsList = questionsList.OrderByDescending(o=>o.score).ToList();
    }

    public async void LoadQuestionsStatistics(int currQuestionsIndex)
    {
        if (currQuestionsIndex == 0)
        {
        for (int i = 0; i < Mathf.Min(MaxStats, questionsList.Count); i++)
        {
            Debug.Log(questionsList[i].username);
            Debug.Log(questionsList[i].score);
                //if ((studentList[i] != null ) && (studentList[i].score != 0))
                if ((questionsList[i] != null ))
                {
                    var row = Instantiate(studentrowUI, transform).GetComponent<StudentsRowUI>();
                    row.gameObject.name = "Row" + (i+1).ToString();
                    // row.rank.text = (i + 1).ToString();
                    row.name.text = questionsList[i].username;
                    row.score.text = questionsList[i].score.ToString(); 
                }
            }
        }
        else
        {
            for (int i = 5; i < Mathf.Min(2*MaxStats, questionsList.Count); i++)
            {
            Debug.Log(questionsList[i].username);
            Debug.Log(questionsList[i].score);
                //if ((studentList[i] != null ) && (studentList[i].score != 0))
                if ((questionsList[i] != null ))
                {
                    var row = Instantiate(studentrowUI, transform).GetComponent<StudentsRowUI>();
                    row.gameObject.name = "Row" + (i+1).ToString();
                    // row.rank.text = (i + 1).ToString();
                    row.name.text = questionsList[i].username;
                    row.score.text = questionsList[i].score.ToString(); 
                }
            }
        }
    }

    public void StudentsNextPage()
    {
        currStudentsIndex = 1;
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        LoadStudentsStatistics(currStudentsIndex);
    }

    public void StudentsPrevPage()
    {
        currStudentsIndex = 0;
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        LoadStudentsStatistics(currStudentsIndex);
    }

    public void QuestionsNextPage()
    {
        currQuestionsIndex = 1;
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        LoadQuestionsStatistics(currQuestionsIndex);
    }

    public void QuestionsPrevPage()
    {
        currQuestionsIndex = 0;
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        LoadQuestionsStatistics(currQuestionsIndex);
    }

    void Update()
    {
        
    }

    public void BackButtonClick() {
        SceneManager.LoadScene("TeacherWelcomeUI");
    }

}