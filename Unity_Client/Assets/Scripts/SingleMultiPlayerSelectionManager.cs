using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleMultiPlayerSelectionManager : MonoBehaviour
{
    public void Start() { // when activated start
        // PlayerPrefs.DeleteAll();
    }

    public void SinglePlayerSelected()
    {
        PlayerPrefs.SetString("gameTypeSelected", "Single");
        SceneManager.LoadScene("WorldAndStageSelectionUI");

    }

    public void MultiPlayerSelected()
    {
        PlayerPrefs.SetString("gameTypeSelected", "Multi");
        SceneManager.LoadScene("WorldAndStageSelectionUI");

    }

}
