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

public class PostAssignmentManager3 : MonoBehaviour
{

    private HttpManager http;
    private SceneLoaderManager scene;
    private List<StudentList> studentList;

    public Text stuName1;
    public Text stuName2;
    public Text stuName3;
    public Text stuName4;

    int StuRows = 3;
    int currStuIndex = 0;
    // private List<Student> studentList = new List<Student>();
    void Start()
    {
        SetStudentTextBox();
        GetStudentData();
        DisplayStudentData(currStuIndex);
        
    }

    public class StudentList{
        public StudentList(string username, string password){
            this.username = username;
            this.password = password;
        }

        public string username { get; set; }
        public string password { get; set; }
    }

    public void GetStudentData(){
        http = new HttpManager();
        var url = "http://172.21.148.165/login_student";
        var responseStr = http.Post(url, ""); 
        Debug.Log(responseStr);
        studentList = JsonConvert.DeserializeObject<List<StudentList>>(responseStr);
        studentList = studentList.ToList();
        Debug.Log(studentList);
    }

    public void DisplayStudentData(int currStuIndex){
        int idx = currStuIndex;
        Debug.Log("Loadig Studing data now...");
        stuName1.text = studentList[idx].username;
        stuName2.text = studentList[idx+1].username;
        stuName3.text = studentList[idx+2].username;
        stuName4.text = studentList[idx+3].username;

        Debug.Log("Student data loaded successfully...");
    }

    public void StuPrevPage(){
        currStuIndex = currStuIndex + StuRows;
        Debug.Log("Showing previous page of question data...");
        Debug.Log(currStuIndex);
        DisplayStudentData(currStuIndex);
    }

    public void StuNextPage(){
        currStuIndex = currStuIndex + StuRows;
        DisplayStudentData(currStuIndex);
    }

    public void TargetStudentPageCancelButton(){
        SceneManager.LoadScene("PostAssignment-P2");
    }

    public void TargetStudentPageConfirmButton(){
        SceneManager.LoadScene("PostAssignment-P2");
    }

    public void SetStudentTextBox(){
        stuName1=GameObject.Find("stu-name-1").GetComponent<Text>();
        stuName2=GameObject.Find("stu-name-2").GetComponent<Text>();
        stuName3=GameObject.Find("stu-name-3").GetComponent<Text>();
        stuName4=GameObject.Find("stu-name-4").GetComponent<Text>();
    }

}
