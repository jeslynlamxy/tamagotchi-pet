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

    private List<Question> questionsStat;

    private List<Stat> stats;

    private List<Question> questionList;

    private DataManager dataController;

    private string currStatsPage = "students";

    private int currStudentsIndex = 0;

    private int currQuestionsIndex = 0;

    public StudentsRowUI studentrowUI;

    public QuestionsRowUi questionsrowUI;

    int MaxStats = 5; // Number of scores to be shown on one page

    void Start() {
        //currLeaderboardIndex = 0;
        // GetStudentsStatsData();
        GetQuestionsStatsData();
        // LoadStudentsStatistics(0);
        LoadQuestionsStatistics(0);
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

    // public QuestionList()
    // {
    //     dataController = FindObjectOfType<DataManager> ();
    //     currentRoundData = dataController.GetSinglePlayerInstance();

    //     // string roundId = currentRoundData.roundId;
    //     // List<Question> questionList = currentRoundData.questionList;
    //     // List<Stat> statList = currentRoundData.statList;
    // }

    public class Stat
    {
        public Stat(string statId, string roundId, string questionId, string studentUsername, int timing, int currentHealth, bool isSkillLeft)
        {
            this.statId = statId;
            this.roundId = roundId;
            this.questionId = questionId;
            this.studentUsername = studentUsername;
            this.timing = timing;
            this.currentHealth = currentHealth;
            this.isSkillLeft = isSkillLeft;
        }
        public string statId { get; set; }
        public string roundId { get; set; }
        public string questionId { get; set; }
        public string studentUsername { get; set; }
        public int timing { get; set; }
        public int currentHealth { get; set; }
        public bool isSkillLeft { get; set; }
    }

    public class Question
    {
        public Question(string questionId, string questionText, int answerIndex, List<string> answersText, string worldTopic, string specificSection, string questionStandard)
        {
            this.questionId = questionId;
            this.questionText = questionText;
            this.answerIndex = answerIndex;
            this.answersText = answersText;
            this.worldTopic = worldTopic;
            this.specificSection = specificSection;
            this.questionStandard = questionStandard;

        }
        public string questionId { get; set; }
        public string questionText { get; set; }
        public int answerIndex { get; set; }
        public List<string> answersText { get; set; }
        public string worldTopic { get; set; }
        public string specificSection { get; set; }
        public string questionStandard { get; set; } // simple and complex
    }

    // public class StatList
    // {
    //     public StatList(string statId, string roundId, string questionId, string studentUsername, int timing, int currentHealth, bool isSkillLeft)
    //     {
    //         this.statId = statId;
    //         this.roundId = roundId;
    //         this.questionId = questionId;
    //         this.studentUsername = studentUsername;
    //         this.timing = timing;
    //         this.currentHealth = currentHealth;
    //         this.isSkillLeft = isSkillLeft;
    //     }
    //     public string statId { get; set; }
    //     public string roundId { get; set; }
    //     public string questionId { get; set; }
    //     public string studentUsername { get; set; }
    //     public int timing { get; set; }
    //     public int currentHealth { get; set; }
    //     public bool isSkillLeft { get; set; }
    // }

    // public class QuestionsList
    // {
    //     public QuestionsList(string roundId, string studentId, string sldcWorld, string specificSection, string difficultyLevel, List<Stat> statlist, List<Question>questionList, Pet CharacterUsed)
    //     {
    //         this.roundId = roundId;
    //         this.studentId = studentId;
    //         this.sldcWorld = sldcWorld;
    //         this.specificSection = specificSection;
    //         this.difficultyLevel = difficultyLevel;
    //         this.statList = statList;
    //         this.questionList = questionList;
    //         this.characterUsed = characterUsed;
    //         this.finalScore = finalScore;
    //         this.rewardedFood = rewardedFood;
    //         this.rewardedWater = rewardedWater;
    //     }

    //     public string roundId { get; set; }
    //     public string studentId { get; set; }
    //     public string sldcWorld { get; set; } // different sldc stages
    //     public string specificSection { get; set; } // section 1, 2, 3, 4
    //     public string difficultyLevel { get; set; } // level 1, 2, 3, 4
    //     public Pet characterUsed { get; set; }
    //     // programmer's end
    //     public List<Question> questionList { get; set; }
    //     public List<Stat> statList { get; set; }
    //     // student's world
    //     public int finalScore { get; set; } 
    //     public int rewardedFood { get; set; }
    //     public int rewardedWater { get; set; }

    // }

    public void GetQuestionsStatsData()
    {
        http = new HttpManager();
        var url = "http://172.21.148.165/get_stats"; // change 
        var responseStr = http.Post(url, ""); 
        Debug.Log(responseStr);
        // currentRoundData = dataController.GetSinglePlayerInstance();
        // questionsStat = JsonConvert.DeserializeObject<List<QuestionsList>>(responseStr);
        stats = JsonConvert.DeserializeObject<List<Stat>>(responseStr);
        // questionsStat = questionsStat.ToList();
        // Debug.Log(questionsStat[1].statList);
        Debug.Log(stats.Count);
        // questionsList = questionsList.OrderByDescending(o=>o.score).ToList();
    }

    public async void LoadQuestionsStatistics(int currQuestionsIndex)
    {
        if (currQuestionsIndex == 0)
        {
        for (int i = 0; i < Mathf.Min(MaxStats, stats.Count); i++)
        {
            Debug.Log(stats[i].questionId);
            Debug.Log(stats[i].timing);
                //if ((studentList[i] != null ) && (studentList[i].score != 0))
                if ((stats[i] != null ))
                {
                    var row = Instantiate(questionsrowUI, transform).GetComponent<QuestionsRowUi>();
                    row.gameObject.name = "Row" + (i+1).ToString();
                    // row.rank.text = (i + 1).ToString();
                    row.questions.text = stats[i].questionId;
                    row.timing.text = stats[i].timing.ToString(); 
                }
            }
        }
        else
        {
            for (int i = 5; i < Mathf.Min(2*MaxStats, stats.Count); i++)
            {
                Debug.Log(stats[i].questionId);
                Debug.Log(stats[i].timing);
                //if ((studentList[i] != null ) && (studentList[i].score != 0))
                if ((stats[i] != null ))
                {
                    var row = Instantiate(questionsrowUI, transform).GetComponent<QuestionsRowUi>();
                    row.gameObject.name = "Row" + (i+1).ToString();
                    // row.rank.text = (i + 1).ToString();
                    row.questions.text = stats[i].questionId;
                    row.timing.text = stats[i].timing.ToString(); 
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