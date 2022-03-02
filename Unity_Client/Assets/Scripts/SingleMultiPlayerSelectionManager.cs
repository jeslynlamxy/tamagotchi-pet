using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMultiPlayerSelectionManager : MonoBehaviour
{
    public void IndividualButton()
    {
        PlayerPrefs.SetString("gameTypeSelected", "Single");
    }

    public void CompeteButton()
    {
        PlayerPrefs.SetString("gameTypeSelected", "Multi");
    }
}
