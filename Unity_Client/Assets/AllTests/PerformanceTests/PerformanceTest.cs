using System.Collections;
using NUnit.Framework;
using Unity.PerformanceTesting;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Profiling;
using System;
using TMPro;

public class PerformanceTest
{
    // Test for Login
    [UnityTest, Performance]
    public IEnumerator Login()
    {
        using (Measure.Scope(new SampleGroup("Setup.LoadScene")))
        {
            SceneManager.LoadScene("StudentLoginUI");
        }
        yield return null;

        yield return new WaitForSeconds(3);

        TMP_InputField usernameInput = GameObject.Find("InputUsername").GetComponent<TMP_InputField>();
        usernameInput.text = "studentH";
        usernameInput.textComponent.SetText("studentH");


        TMP_InputField passwordInput = GameObject.Find("InputPassword").GetComponent<TMP_InputField>();
        passwordInput.text = "studenth123";
        passwordInput.textComponent.SetText("studenth123");

        Button LoginButton = GameObject.Find("LoginButton").GetComponent<Button>();
        LoginButton.onClick.Invoke();

        yield return new WaitForSeconds(1);

        yield return Measure.Frames().Run();
    }

    // Loading Scene Measurement
    [UnityTest, Performance]
    public IEnumerator Loading_Scene_Measurement()
    {
        using (Measure.Scope(new SampleGroup("Setup.LoadScene")))
        {
            SceneManager.LoadScene("LeaderboardUI");
        }
        yield return null;

        yield return Measure.Frames().Run();
    }


}