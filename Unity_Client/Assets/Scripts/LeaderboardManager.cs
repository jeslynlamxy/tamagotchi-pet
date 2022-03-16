using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

public class LeaderboardManager : MonoBehaviour
{
    private HttpManager http;
    private SceneLoaderManager scene;
    //public List<Scores> scoreList;
    private List<ScoreList> userList;
    int MaxScores = 5; // Number of scores to be shown on one page
    public RowUi rowUi;

    void Start()
    {
        GetScoreData();
        LoadLeaderboard();
    }

    public class ScoreList
    {
        public ScoreList(string username, int score)
        {
            this.username = username;
            this.score = score;
        }

        public string username { get; set; }
        public int score { get; set; }

    }
    public void GetScoreData()
    {
        http = new HttpManager();
        var url = "http://172.21.148.165/get_Leaderboard"; 
        var responseStr = http.Post(url, ""); 
        Debug.Log(responseStr);
        userList = JsonConvert.DeserializeObject<List<ScoreList>>(responseStr);
        userList = userList.OrderByDescending(o=>o.score).ToList();
    }

    // TODO messed up pretty ui - think of how to fix,,
    public async void LoadLeaderboard()
    {
        for (int i = 0; i < Mathf.Min(MaxScores, userList.Count); i++)
        {
            Debug.Log(userList[i].username);
            Debug.Log(userList[i].score);
            if ((userList[i] != null ) && (userList[i].score != 0))
            {
                var row = Instantiate(rowUi, transform).GetComponent<RowUi>();
                row.gameObject.name = "Row" + (i + 1).ToString();
                row.rank.text = (i + 1).ToString();
                row.name.text = userList[i].username;
                row.score.text = userList[i].score.ToString(); 
            }
        }
    }
}