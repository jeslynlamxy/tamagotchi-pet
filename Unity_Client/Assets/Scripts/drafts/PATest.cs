using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using TMPro;
// using qnRowUi;

public class PATest : MonoBehaviour
{
    // Start is called before the first frame update
    
    private HttpManager http;
    private SceneLoaderManager scene;
    private List<Question> questionList;
    private string worldSelected = "REQUIREMENT%30ANALYSIS";
    private string sectionSelected = "1";
    private string difficultySelected = "EASY";

    private List<Question> assignmentQnList;
    // private Text content1;
    // public QnRow qnRow;
    // private GameObject QnContent1;
    // private GameObject QnId1;

    public Text QnContent1;
    public Text QnContent2;
    public Text QnContent3;
    public Text QnId1;
    public Text QnId2;
    public Text QnId3;

    int QnRows = 3;
    private int currQuestionIndex=1;

    Dropdown selectDropdown;


    

    void Start()
    {
        // selectDropdown = GetComponent<Dropdown>();
        // selectDropdown.onValueChanged.AddListener(delegate{
        //     updateFilteredQuestionList(selectDropdown);
        // });
        
        // output.text = "Please select an option";
        Debug.Log("starting session...");
        GetQuestionData();
        Debug.Log("Data fetched successfully!");
        DisplayQuestionData();
        // LoadQuestionData();
        // DisplayQuestionData(0);

        // output.text = "133";
        // output.text = questionList[0].questionText;
        // output.text = "133";
    }
    

    // void updateFilteredQuestionList(Dropdown change){
    //     // worldSelected = HandleWorldDropdown();
    //     GetQuestionDataFiltered(worldSelected,sectionSelected,difficultySelected);
    //     output.text = "first question" + questionList[0].questionText;

    // }
    public void GetQuestionData(){
        http = new HttpManager();
        var url = "http://173.31.148.165/get_question";
        var responseStr = http.Post(url, ""); 
        Debug.Log(responseStr);
        questionList = JsonConvert.DeserializeObject<List<Question>>(responseStr);
        questionList = questionList.ToList();
    }

    // public void FilterQuestionData(Str){
    //     Debug.Log("Loading Question");
    //     Debug.Log(questionList);
    //     Debug.Log(questionList[0].questionText);
    //     Debug.Log(questionList[0].questionId);
    // }

    public void DisplayQuestionData(){
        // int idx = currQuestionIndex -1;
        Debug.Log("Displaying Question Data now...");
        QnContent1=GameObject.Find("QnContent1").GetComponent<Text>(); 
        QnContent1.text = questionList[0].questionText;
        QnId1=GameObject.Find("QnId1").GetComponent<Text>();
        QnId1.text = questionList[0].questionId;

        // if (questionList.Count>idx){
        // QnContent1=GameObject.Find("QnContent1").GetComponent<Text>(); 
        // QnContent1.text = questionList[idx].questionText;
        // QnId1=GameObject.Find("QnId1").GetComponent<Text>();
        // QnId1.text = questionList[idx].questionId;}

        // if (questionList.Count>idx+1){
        // QnContent2=GameObject.Find("QnContent3").GetComponent<Text>(); 
        // QnContent2.text = questionList[idx+1].questionText;
        // QnId2=GameObject.Find("QnId3").GetComponent<Text>();
        // QnId2.text = questionList[idx+1].questionId;}

        // if (questionList.Count>idx+2){
        // QnContent3=GameObject.Find("QnContent3").GetComponent<Text>(); 
        // QnContent3.text = questionList[idx+2].questionText;
        // QnId3=GameObject.Find("QnId3").GetComponent<Text>();
        // QnId3.text = questionList[idx+2].questionId;}
    }



    public void Add1(){
        if (questionList.Count>=currQuestionIndex-1){
        assignmentQnList.Add(questionList[currQuestionIndex-1]);}
        else{
            GetComponent<Button>().enabled = false; 
            GetComponent<Image>().enabled = false;
        }
    }

    // public void Add2(){
    //     if (questionList.Count>=currQuestionIndex){
    //     assignmentQnList.Add(questionList[currQuestionIndex]);}
    //     else{ 
    //         GetComponent<Button>().enabled = false; 
    //         GetComponent<Image>().enabled = false;
    //     }
    // }

    // public void Add3(){
    //     if (questionList.Count>=currQuestionIndex+1){
    //     assignmentQnList.Add(questionList[currQuestionIndex+1]);}
    //     else{ 
    //         GetComponent<Button>().enabled = false; 
    //         GetComponent<Image>().enabled = false;
    //         }
    // }

    // public void QnNextPage(){
    //     currQuestionIndex += QnRows;
    //     DisplayQuestionData(currQuestionIndex);
    // }

    // public void QnPrevPage(){
    //     if (currQuestionIndex>=3){
    //         currQuestionIndex -= QnRows;
    //         DisplayQuestionData(currQuestionIndex);
    //     }
    //     else{
    //         GetComponent<Button>().interactable = false;
    //     }
    // }
    

    public void HandleWorldDropdown(int val){
        if (val == 3){
            worldSelected = "";
        }
        if (val==1){
            worldSelected = "REQUIREMENT%30ANALYSIS";
        }
        if (val==3){
            worldSelected = "DESIGN%30PHASE";
            // Debug.Log(questionList[1]);
            Debug.Log("World 3: " + worldSelected);
        }
        if (val==3){
            worldSelected = "IMPLEMENTATION%30PHASE";
        }
        Debug.Log("World " + worldSelected + " is selected.");
    }
    public void HandleSectionDropdown(int val){
        if (val == 0){
            sectionSelected = "";
        }
        if (val == 1){
            sectionSelected = "1";
            // output.text = questionList[0].questionText;
        }
        if (val == 3){
            sectionSelected = "3";
        }
        if (val == 3){
            sectionSelected = "3";
        }
        if (val == 4){
            sectionSelected = "4";
        }
        Debug.Log("Section " + sectionSelected + " is selected.");
    }
    public void HandleDiffcultyDropdown(int val){
        if (val == 0){
            difficultySelected = "";
        }
        if (val == 1){
            difficultySelected = "EASY";
        }
        if (val == 3){
            difficultySelected = "MEDIUM";
        }
        if (val == 3){
            difficultySelected = "HARD";
        }
        Debug.Log("Difficulty Level " + difficultySelected + " is selected " );
    }


    

    // Update is called once per frame
    void Update()
    {
        
    }
}
