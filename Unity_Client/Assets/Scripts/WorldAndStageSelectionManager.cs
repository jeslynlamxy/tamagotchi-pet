using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WorldAndStageSelectionManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI srsText, umlText;

    [SerializeField]
    private TextMeshProUGUI stage1, stage2, stage3, stage4, stage5, stage6, stage7, stage8;


    public void WorldSRSSelected()
    {
        PlayerPrefs.SetString("worldSelected", "SRS");
        srsText.color = Color.red;
        umlText.color = Color.black;

    }

    public void WorldUMLSelected()
    {
        PlayerPrefs.SetString("worldSelected", "UML");
        srsText.color = Color.black;
        umlText.color = Color.red;
    }

    public void stage1Selected()
    {
        PlayerPrefs.SetString("stageSelected", "1");
        stage1.color = Color.red;
        stage2.color = Color.black;
        stage3.color = Color.black;
        stage4.color = Color.black;
        stage5.color = Color.black;
        stage6.color = Color.black;
        stage7.color = Color.black;
        stage8.color = Color.black;
    }

    public void stage2Selected()
    {
        PlayerPrefs.SetString("stageSelected", "2");
        stage1.color = Color.black;
        stage2.color = Color.red;
        stage3.color = Color.black;
        stage4.color = Color.black;
        stage5.color = Color.black;
        stage6.color = Color.black;
        stage7.color = Color.black;
        stage8.color = Color.black;
    }

    public void stage3Selected()
    {
        PlayerPrefs.SetString("stageSelected", "3");
        stage1.color = Color.black;
        stage2.color = Color.black;
        stage3.color = Color.red;
        stage4.color = Color.black;
        stage5.color = Color.black;
        stage6.color = Color.black;
        stage7.color = Color.black;
        stage8.color = Color.black;
    }

    public void stage4Selected()
    {
        PlayerPrefs.SetString("stageSelected", "4");
        stage1.color = Color.black;
        stage2.color = Color.black;
        stage3.color = Color.black;
        stage4.color = Color.red;
        stage5.color = Color.black;
        stage6.color = Color.black;
        stage7.color = Color.black;
        stage8.color = Color.black;
    }

    public void stage5Selected()
    {
        PlayerPrefs.SetString("stageSelected", "5");
        stage1.color = Color.black;
        stage2.color = Color.black;
        stage3.color = Color.black;
        stage4.color = Color.black;
        stage5.color = Color.red;
        stage6.color = Color.black;
        stage7.color = Color.black;
        stage8.color = Color.black;
    }

    public void stage6Selected()
    {
        PlayerPrefs.SetString("stageSelected", "6");
        stage1.color = Color.black;
        stage2.color = Color.black;
        stage3.color = Color.black;
        stage4.color = Color.black;
        stage5.color = Color.black;
        stage6.color = Color.red;
        stage7.color = Color.black;
        stage8.color = Color.black;
    }

    public void stage7Selected()
    {
        PlayerPrefs.SetString("stageSelected", "7");
        stage1.color = Color.black;
        stage2.color = Color.black;
        stage3.color = Color.black;
        stage4.color = Color.black;
        stage5.color = Color.black;
        stage6.color = Color.black;
        stage7.color = Color.red;
        stage8.color = Color.black;
    }

    public void stage8Selected()
    {
        PlayerPrefs.SetString("stageSelected", "8");
        stage1.color = Color.black;
        stage2.color = Color.black;
        stage3.color = Color.black;
        stage4.color = Color.black;
        stage5.color = Color.black;
        stage6.color = Color.black;
        stage7.color = Color.black;
        stage8.color = Color.red;
    }

    public void ComfirmButtonClicked() {
        // check both playerpref steady then continue
        if (PlayerPrefs.HasKey("worldSelected") && PlayerPrefs.HasKey("stageSelected")) {
            SceneManager.LoadScene("CharacterSelectionUI");
        }
    }

    public void BackButtonClicked() {
        SceneManager.LoadScene("CharacterSelectionUI");
    }

}
