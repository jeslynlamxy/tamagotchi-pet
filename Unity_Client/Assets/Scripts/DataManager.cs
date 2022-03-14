using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement; // can load scene
public class DataManager : MonoBehaviour
{
    public SinglePlayerRoundData SinglePlayerInstance;
    public MultiPlayerRoundData MultiPlayerInstance;
    // public Student student { get; set; }
    public string username { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("MainPageUI");
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public SinglePlayerRoundData GetSinglePlayerInstance()
    {
        return SinglePlayerInstance;
    }

    public MultiPlayerRoundData GetMultiPlayerInstance()
    {
        return MultiPlayerInstance;
    }
    public string generateUID()
    {
        var ticks = DateTime.Now.Ticks;
        string guid = Guid.NewGuid().ToString();
        string uniqueSessionId = ticks.ToString() + '-' + guid; //guid created by combining ticks 
        return uniqueSessionId;
    }
}
