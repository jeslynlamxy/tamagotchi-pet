using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;
using System.Linq;

public class World_Select_Script : MonoBehaviour
{

    public static string worldChoice;

    // Start is called before the first frame update
    public void onPlanningSelect()
    {
        worldChoice = "planning" ;
        SceneManager.LoadScene("QuestionBankSection");
    }

    public void onDesignSelect()
    {
        worldChoice = "design";
        SceneManager.LoadScene("QuestionBankSection");
    }

    public void onImplementationSelect()
    {
        worldChoice = "implementation";
        SceneManager.LoadScene("QuestionBankSection");
    }

    public void onTestingSelect()
    {
        worldChoice = "testing";
        SceneManager.LoadScene("QuestionBankSection");
    }

    public void onMaintenanceSelect()
    {
        worldChoice = "maintenance";
        SceneManager.LoadScene("QuestionBankSection");
    }



}