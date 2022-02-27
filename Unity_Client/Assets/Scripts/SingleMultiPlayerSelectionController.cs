using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMultiPlayerSelectionController : MonoBehaviour
{
    public void IndividualButton()
    {
        StudentData.gameTypeSelected = "Single";
    }

    public void CompeteButton()
    {
        StudentData.gameTypeSelected = "Multi";
    }
}
