using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Assignment : MonoBehaviour
{
    public int assignmentId { get; set; }
    public int totalMark { get; set; }
    public string assignmentName {get; set; }
    public string assignmentTopic { get; set; }
    public string assignemtnDescriptions {get; set;}
    public dateTime dueDate { get; set; }
    
    
    public List<Question> questionList { get; set; } // get from backend
    public List<student> targetStudentList { get; set; } // get from backend
    
}
