using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // can load scene
public class DataManager : MonoBehaviour
{
    public SinglePlayerRoundData SinglePlayerInstance;

    public Student student { get; set; }

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

    // Update is called once per frame
    void Update()
    {

    }
}
