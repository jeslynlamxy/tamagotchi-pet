using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using SimpleJSON;
using System.Linq;



public class Question_List_Script : MonoBehaviour
{

    List<JSONNode> questionList;
    List<JSONNode> questionStandardList;
    List<JSONNode> questionIdList;
    GameObject studentPopUp;
    public GameObject mainScrollContentView;
    public GameObject ContentDataPanel;
    List<JSONNode> questionContentTextArray = new List<JSONNode>();
    List<JSONNode> questionStandardArray = new List<JSONNode>();
    List<JSONNode> questionIdArray = new List<JSONNode>();
    public static Question editQ;
    public static string questionId;
    public static string selectedWorld = World_Select_Script.worldChoice;
    public static string selectedSectionUnformat = Section_Select_Script.sectionChoice;
    public static string selectedSection = selectedSectionUnformat.Replace(" ", "%20");

    private static string baseQuestionInfoURL;

    //use this for initialization
    void Start()
    {
        editQ = new Question(questionId);
        selectedWorld = World_Select_Script.worldChoice;
        selectedSectionUnformat = Section_Select_Script.sectionChoice;
        selectedSection = selectedSectionUnformat.Replace(" ", "%20");
        transform.Find("Panel_00").Find("World_Section_Subheader_Text").GetComponent<Text>().text = selectedWorld + "/ " + selectedSectionUnformat;
        transform.Find("Panel_00").Find("Button_Add_Question").GetComponent<Button>().onClick.AddListener(addQuestion);
        //need to change the url
        baseQuestionInfoURL = "http://172.21.148.165/get_question_filtered?world=" + selectedWorld + "&section=" + selectedSection;
        StartCoroutine(GetQuestionInfo());
    }

    IEnumerator GetQuestionInfo()
    {
        //GET students' matriculation number in a tutorial group
        UnityWebRequest questionInfoRequest = UnityWebRequest.Get(baseQuestionInfoURL);
        yield return questionInfoRequest.SendWebRequest();
        if (questionInfoRequest.isNetworkError || questionInfoRequest.isHttpError)
        {
            Debug.LogError(questionInfoRequest.error);
            yield break;
        }
        JSONNode questionInfo = JSON.Parse(questionInfoRequest.downloadHandler.text);
        for (int i = 0; i < questionInfo.Count; i++)
        {
            questionContentTextArray.Add(questionInfo[i]["questionText"]);
            questionStandardArray.Add(questionInfo[i]["questionStandard"]);
            questionIdArray.Add(questionInfo[i]["questionId"]);
        }


        questionList = questionContentTextArray;


        questionStandardList = new List<JSONNode>();
        questionStandardList = questionStandardArray;

        questionIdList = new List<JSONNode>();
        questionIdList = questionIdArray;


        if (questionList.Count > 0)
        {
            //noRecordLabel.gameObject.SetActive(false);
            RectTransform rt = (RectTransform)mainScrollContentView.transform;
            for (int i = 0; i < questionList.Count; i++)
            {
                string value = questionList[i];
                string questionStandard = questionStandardList[i];
                string questionId = questionIdList[i];
                GameObject playerTextPanel = (GameObject)Instantiate(ContentDataPanel);
                playerTextPanel.transform.SetParent(mainScrollContentView.transform);
                playerTextPanel.transform.localScale = new Vector3(1, 1, 1);
                playerTextPanel.transform.localPosition = new Vector3(0, 0, 0);
                playerTextPanel.transform.Find("Text_No").GetComponent<Text>().text = (i + 1).ToString();
                playerTextPanel.transform.Find("Text_Question").GetComponent<Text>().text = value;
                playerTextPanel.transform.Find("Text_Difficulty").GetComponent<Text>().text = questionStandard;
                playerTextPanel.transform.Find("Text_Id").GetComponent<Text>().text = questionId;

                playerTextPanel.transform.Find("Text_Difficulty").transform.Find("Button_Manage").GetComponent<Button>().onClick.AddListener(() => {
                    editQ.questionId = playerTextPanel.transform.Find("Text_Id").GetComponent<Text>().text;
                    SceneManager.LoadScene("Question_Bank_Edit");
                });
            }
        }
        //else
       // {
            //noRecordLabel.gameObject.SetActive(true);
       // }
    }

    public void hideQuestionListPopUp()
    {
        studentPopUp.gameObject.SetActive(false);
    }
    public void showQuestionListPopUp()
    {
        studentPopUp.gameObject.SetActive(true);
    }
    private void addQuestion()
    {
        SceneManager.LoadScene("Question_Bank_Add");
    }
}

