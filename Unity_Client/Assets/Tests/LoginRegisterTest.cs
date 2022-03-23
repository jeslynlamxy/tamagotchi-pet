using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LoginRegisterTest
{
    [UnityTest]
    public IEnumerator login_register_check_all_ui_components_truth()
    {
        SceneManager.LoadScene("StudentLoginUI");
        yield return new WaitForSeconds(3);

        TMP_InputField usernameInput = GameObject.Find("InputUsername").GetComponent<TMP_InputField>();
        TMP_InputField passwordInput = GameObject.Find("InputPassword").GetComponent<TMP_InputField>();
        Assert.AreEqual(usernameInput.GetType(), typeof(TMP_InputField));
        Assert.AreEqual(passwordInput.GetType(), typeof(TMP_InputField));

        SceneManager.LoadScene("TeacherLoginUI");
        yield return new WaitForSeconds(3);

        TMP_InputField usernameInputT = GameObject.Find("InputUsername").GetComponent<TMP_InputField>();
        TMP_InputField passwordInputT = GameObject.Find("InputPassword").GetComponent<TMP_InputField>();
        Assert.AreEqual(usernameInputT.GetType(), typeof(TMP_InputField));
        Assert.AreEqual(passwordInputT.GetType(), typeof(TMP_InputField));

    }

    [UnityTest]
    // Comment: Check that username field stores input correctly
    public IEnumerator username_input_on_text_changed()
    {
        SceneManager.LoadScene("StudentLoginUI");
        yield return new WaitForSeconds(3);

        TMP_InputField usernameInput = GameObject.Find("InputUsername").GetComponent<TMP_InputField>();

        usernameInput.text = "testUsername";
        Assert.AreEqual(usernameInput.text, "testUsername");
    }

    [UnityTest]
    // Comment: Check that password field stores input correctly
    public IEnumerator password_input_on_text_changed()
    {
        SceneManager.LoadScene("StudentLoginUI");
        yield return new WaitForSeconds(3);

        TMP_InputField passwordInput = GameObject.Find("InputPassword").GetComponent<TMP_InputField>();

        passwordInput.text = "password";
        Assert.AreEqual(passwordInput.text, "password");
    }

    [UnityTest]
    // Comment: Check that no input register fails and asks user for username
    public IEnumerator no_input_on_register_return_warning()
    {
        SceneManager.LoadScene("StudentLoginUI");
        yield return new WaitForSeconds(3);

        Button registerButton = GameObject.Find("RegisterButton").GetComponent<Button>();
        registerButton.onClick.Invoke();

        yield return new WaitForSeconds(3);

        Text warningMessage = GameObject.Find("MessageLabel").GetComponent<Text>();
        Assert.AreEqual(warningMessage.text, "Enter registration details");
    }

    [UnityTest]
    // Comment: Check that no input register fails and asks user for username
    public IEnumerator no_username_input_on_register_return_warning()
    {
        SceneManager.LoadScene("StudentLoginUI");
        yield return new WaitForSeconds(3);

        TMP_InputField passwordInput = GameObject.Find("InputPassword").GetComponent<TMP_InputField>();
        passwordInput.text = "password";


        Button registerButton = GameObject.Find("RegisterButton").GetComponent<Button>();
        registerButton.onClick.Invoke();

        yield return new WaitForSeconds(3);

        Text warningMessage = GameObject.Find("MessageLabel").GetComponent<Text>();
        Debug.Log(warningMessage.text);
        Assert.AreEqual(warningMessage.text, "Enter registration details");
    }


    [UnityTest]
    // Comment: Check that no input register fails and asks user for username
    public IEnumerator no_password_input_on_register_return_warning()
    {
        SceneManager.LoadScene("StudentLoginUI");
        yield return new WaitForSeconds(3);

        TMP_InputField usernameInput = GameObject.Find("InputUsername").GetComponent<TMP_InputField>();
        usernameInput.text = "testUsername";

        Button registerButton = GameObject.Find("RegisterButton").GetComponent<Button>();
        registerButton.onClick.Invoke();

        yield return new WaitForSeconds(3);

        Text warningMessage = GameObject.Find("MessageLabel").GetComponent<Text>();
        Assert.AreEqual(warningMessage.text, "Enter registration details");
    }
    [UnityTest]
    // Comment: Check that if all three information are given validly, registration is successful
    public IEnumerator correct_information_register_success()
    {
        SceneManager.LoadScene("StudentLoginUI");
        yield return new WaitForSeconds(3);

        TMP_InputField usernameInput = GameObject.Find("InputUsername").GetComponent<TMP_InputField>();
        TMP_InputField passwordInput = GameObject.Find("InputPassword").GetComponent<TMP_InputField>();
        usernameInput.text = "testUsername";
        passwordInput.text = "password";

        Button registerButton = GameObject.Find("RegisterButton").GetComponent<Button>();
        registerButton.onClick.Invoke();

        yield return new WaitForSeconds(3);

        Text warningMessage = GameObject.Find("MessageLabel").GetComponent<Text>();
        Assert.AreEqual(warningMessage.text, "Enter registration details"); // No warning message
    }
}
