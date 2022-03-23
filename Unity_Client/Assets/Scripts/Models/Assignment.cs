using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Assignment : MonoBehaviour
{
    public Assignment(int assignmentId, int totalMark, string assignmentName, string assignmentTopic, string assignmentDescriptions, List<Question>questionList, List<Student> targetStudentList, int dueYear, int dueMonth, int dueDate){ 
        this.assignmentId = assignmentId;
        this.totalMark = totalMark;
        this.assignmentName = assignmentName;
        this.assignmentTopic = assignmentTopic;
        this.assignmentDescriptions = assignmentDescriptions;
        this.questionList = questionList;
        this.targetStudentList = targetStudentList;
       // this.deuDate = new DateTime(Year, Month, Date, 23, 59, 00);
    }
    public int assignmentId { get; set; }
    public int totalMark { get; set; }
    public string assignmentName {get; set; }
    public string assignmentTopic { get; set; }
    public string assignmentDescriptions {get; set;}    
    
    public List<Question> questionList { get; set; } // get from backend
    public List<Student> targetStudentList { get; set; } // get from backend
    
}
