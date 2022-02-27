using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMultiPlayerSelectionController : MonoBehaviour
{
    // Start is called before the first frame update
    public void IndividualButton()
    {
        PlayerPrefs.SetString("SingleOrMulti", "Single");
    }

    // Update is called once per frame
    public void CompeteButton()
    {
        PlayerPrefs.SetString("SingleOrMulti", "Multi");
    }
}
