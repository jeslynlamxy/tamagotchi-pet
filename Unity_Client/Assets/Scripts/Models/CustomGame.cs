using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomGame : MonoBehaviour
{
   public int customeGameId { get; set; }
   public string customeGameName { get; set; }
   public string customGameDescription { get; set; }

   public List<Student> shareStudentList { get; set; }
}
