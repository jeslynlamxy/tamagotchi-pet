using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomGame : MonoBehaviour
{

   public CustomGame(int customeGameId, string customeGameName, string customGameDescription, List<Student> shareStudentList, List<Question> questionList){
      this.customeGameId = customeGameId;
      this.customeGameName = customeGameName;
      this.customGameDescription = customGameDescription;
      this.shareStudentList = shareStudentList;
      this.questionList = questionList;
   }
   public int customeGameId { get; set; }
   public string customeGameName { get; set; }
   public string customGameDescription { get; set; }

   public List<Student> shareStudentList { get; set; }
   public List<Question> questionList { get; set; }
}
