using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using TMPro;
// using qnRowUi;



public class PostAssignmentManager1 : MonoBehaviour
{
    private HttpManager http;
    private SceneLoaderManager scene;
    private List<Question> questionList;
    private List<Question> assignmentQnList = new List<Question>();
    private List<Student> studentList = new List<Student>();
    private string worldSelected = "REQUIREMENT%20ANALYSIS";
    private string sectionSelected = "1";
    private string difficultySelected = "EASY";
    public Button addButton1;
    public Button addButton2;
    public Button addButton3;

    public Button removeButton1;
    public Button removeButton2;
    public Button removeButton3;
    
    public Text QnContent1;
    public Text QnContent2;
    public Text QnContent3;
    public Text QnId1;
    public Text QnId2;
    public Text QnId3;

    public Text AddedQnId1;
    public Text AddedQnId2;
    public Text AddedQnId3;

    public Text AddedQnContent1;
    public Text AddedQnContent2;
    public Text AddedQnContent3;

    int QnRows = 3;
    private int AssignmtRows = 3;
    private int currQuestionIndex = 0;
    private int currAssimtQnIndex = 0;    

    void Start()
    {
        Debug.Log("starting session...");
        SetButtons();
        SetTextBoxObjects();
        Debug.Log("Fetching question data now....");
        GetQuestionData();
        Debug.Log("Data fetched successfully!");
        DisplayQuestionData(currQuestionIndex);
        DisplayAddedQuestionData(currAssimtQnIndex);
    }
    
    public void GetQuestionData(){
        http = new HttpManager();
        var url = "http://172.21.148.165/get_question";
        var responseStr = http.Post(url, ""); 
        Debug.Log(responseStr);
        questionList = JsonConvert.DeserializeObject<List<Question>>(responseStr);
        questionList = questionList.ToList();
        Debug.Log(questionList);
    }

    public void LoadQuestionData(){
        Debug.Log("Loading Question");
        Debug.Log(questionList);
        Debug.Log(questionList[0].questionText);
        Debug.Log(questionList[0].questionId);
    }

    public void DisplayQuestionData(int currQuestionIndex){
        int idx = currQuestionIndex;
        Debug.Log("Displaying Question Data now. current displayed index is " + idx);        

        if (questionList.Count>idx){
        QnContent1.text = questionList[idx].questionText;
        QnId1.text = questionList[idx].questionId;}
        else{
            Debug.Log("Row 1 is empty");
            QnContent1.text = "";
            QnId1.text = "";
            // addButton1.enabled = false;
        }
        if (questionList.Count>idx+1){
        QnContent2.text = questionList[idx+1].questionText;
        QnId2.text = questionList[idx+1].questionId;
        }
        else{
            Debug.Log("Row 2 is empty");
            QnContent2.text = "";
            QnId2.text = "";
            // addButton2.enabled = false;
        }

        if (questionList.Count>idx+2){
        QnContent3.text = questionList[idx+2].questionText;
        QnId3.text = questionList[idx+2].questionId;
        }
        else{
            Debug.Log("Row 3 is empty");
            QnContent3.text = "";
            QnId3.text = "";
            // addButton3.enabled = false;
        }
    }

    public void DisplayAddedQuestionData(int currAssimtQnIndex){
        int idx_assignmt = currAssimtQnIndex;
        Debug.Log("Refersing currently added questions. current Assignment Index displayed is "+currAssimtQnIndex);
        if (assignmentQnList.Count>idx_assignmt){
            AddedQnContent1.text = assignmentQnList[idx_assignmt].questionText;
            AddedQnId1.text =assignmentQnList[idx_assignmt].questionId;
        }
        else{
            AddedQnContent1.text = "";
            AddedQnId1.text = "";
            // addButton1.enabled = false;
        }
        if (assignmentQnList.Count>idx_assignmt+1){
            AddedQnContent2.text = assignmentQnList[idx_assignmt].questionText;
            AddedQnId2.text =assignmentQnList[idx_assignmt].questionId;
        }
        else{
            AddedQnContent2.text = "";
            AddedQnId2.text = "";
            // addButton2.enabled = false;
        }
        if (assignmentQnList.Count>idx_assignmt+2){
            AddedQnContent3.text = assignmentQnList[idx_assignmt].questionText;
            AddedQnId3.text =assignmentQnList[idx_assignmt].questionId;
        }
        else{
            AddedQnContent3.text = "";
            AddedQnId3.text = "";
            // addButton3.enabled = false;
        }

    }

    public void QnNextPage(){
        currQuestionIndex += QnRows;
        Debug.Log("Showing next page of question data. questionIndex: " + currQuestionIndex);
        DisplayQuestionData(currQuestionIndex); 
    }

    public void QnPrevPage(){
        Debug.Log("Current Index to be decreased later: " + currQuestionIndex);
        // GetComponent<Button>().interactable = true;
        currQuestionIndex = currQuestionIndex - 3;
        // currQuestionIndex = -currQuestionIndex;
        Debug.Log("Showing previous page of question data. Question index: " + currQuestionIndex);
        DisplayQuestionData(currQuestionIndex);
    }

    public void AssignmentNextPage(){
        currAssimtQnIndex += AssignmtRows;
        DisplayAddedQuestionData(currAssimtQnIndex);
    }

    public void AssignmentPrevPage(){
        currAssimtQnIndex -= AssignmtRows;
        DisplayAddedQuestionData(currAssimtQnIndex);
    }

    public void Add1(){
        if (questionList.Count>=currQuestionIndex){
            assignmentQnList.Add(questionList[currQuestionIndex]);
            Debug.Log("Question in row 1 added successfully! ");
            DisplayAddedQuestionData(currAssimtQnIndex);
        }
        else{
            // GetComponent<Button>().enabled = false; 
            // GetComponent<Image>().enabled = false;
        }
    }

    public void Add2(){
        if (questionList.Count>=currQuestionIndex+1){
            assignmentQnList.Add(questionList[currQuestionIndex+1]);
            Debug.Log("Question in row 2 added successfully! ");
            DisplayAddedQuestionData(currAssimtQnIndex);
        }
        else{
            // GetComponent<Button>().enabled = false; 
            // GetComponent<Image>().enabled = false;
        }
    }

    public void Add3(){
        if (questionList.Count>=currQuestionIndex+2){
            assignmentQnList.Add(questionList[currQuestionIndex+2]);
            Debug.Log("Question in row 3 added successfully! ");
            DisplayAddedQuestionData(currAssimtQnIndex);
        }
        else{
            // GetComponent<Button>().enabled = false; 
            // GetComponent<Image>().enabled = false;
        }
    }


    public void Remove1(){
        if (assignmentQnList.Count>=1){
            assignmentQnList.RemoveAt(0);
            DisplayQuestionData(currQuestionIndex);
            }
        else{
            // GetComponent<Button>().enabled = false;
            // GetComponent<Image>().enabled = false;
        }
    }

    public void Remove2(){
        if (assignmentQnList.Count>=2){
            assignmentQnList.RemoveAt(1);
            DisplayQuestionData(currQuestionIndex);
            }
        else{
            // GetComponent<Button>().enabled = false;
            // GetComponent<Image>().enabled = false;
        }
    }

    public void Remove3(){
        if (assignmentQnList.Count>=3){
            assignmentQnList.RemoveAt(2);
            DisplayQuestionData(currQuestionIndex);
            }
        else{
            // GetComponent<Button>().enabled = false;
            // GetComponent<Image>().enabled = false;
        }
    }

    public void HandleWorldDropdown(int val){
        if (val == 0){
            worldSelected = "";
        }
        if (val==1){
            worldSelected = "REQUIREMENT%30ANALYSIS";
        }
        if (val==3){
            worldSelected = "DESIGN%30PHASE";
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


    public void SetButtons(){
        addButton1 = GameObject.Find("Add-button-1").GetComponent<Button>();
        addButton2 = GameObject.Find("Add-button-2").GetComponent<Button>();
        addButton3 = GameObject.Find("Add-button-3").GetComponent<Button>();

        removeButton1 = GameObject.Find("remove-button-1").GetComponent<Button>();
        removeButton2 = GameObject.Find("remove-button-2").GetComponent<Button>();
        removeButton3 = GameObject.Find("remove-button-3").GetComponent<Button>();
    }

    public void SetTextBoxObjects(){
        QnContent1=GameObject.Find("QnContent1").GetComponent<Text>(); 
        QnId1=GameObject.Find("QnId1").GetComponent<Text>();
        QnContent2=GameObject.Find("QnContent2").GetComponent<Text>(); 
        QnId2=GameObject.Find("QnId2").GetComponent<Text>();
        QnContent3=GameObject.Find("QnContent3").GetComponent<Text>(); 
        QnId3=GameObject.Find("QnId3").GetComponent<Text>();

        AddedQnContent1 = GameObject.Find("addedQnContent1").GetComponent<Text>();
        AddedQnId1 = GameObject.Find("addedQnId1").GetComponent<Text>();
        AddedQnContent2 = GameObject.Find("addedQnContent2").GetComponent<Text>();
        AddedQnId2 = GameObject.Find("addedQnId2").GetComponent<Text>();
        AddedQnContent3 = GameObject.Find("addedQnContent3").GetComponent<Text>();
        AddedQnId3 = GameObject.Find("addedQnId3").GetComponent<Text>();
    }

    public void nextPageButton(){
        SceneManager.LoadScene("PostAssignment-P2");    
    }

     public void backToMainButton(){
        SceneManager.LoadScene("TeacherWelcomeUI");    
    }

    public void PAInputDetailsPageBackButton(){
        SceneManager.LoadScene("PostAssignment-P2");
    }
    public void SelectTargetStudentButton(){
        SceneManager.LoadScene("PostAssignment-P3");
    }

    public void TargetStudentPageCancelButton(){
        SceneManager.LoadScene("PostAssignment-P2");
    }

    public void TargetStudentPageConfirmButton(){
        SceneManager.LoadScene("PostAssignment-P2");
    }

    public void goToPostAssignment(){
        SceneManager.LoadScene("PostAssignment-P1");
    }



}
