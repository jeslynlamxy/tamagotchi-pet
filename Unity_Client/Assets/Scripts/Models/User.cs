using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class User
{
    public static string userName;
    // public static int userID;
    public static string email;

    public int UserId { get; set; }
    public int Id { get; set; }
    public int Title { get; set; }
    public int Completed { get; set; }

}