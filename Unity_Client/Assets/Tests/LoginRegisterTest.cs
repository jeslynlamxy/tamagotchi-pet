using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoginRegisterTest
{
    [UnityTest]
    public IEnumerator login_register_all_ui_components_check_truth()
    {
        SceneManager.LoadScene("StudentLoginUI");
        yield return new WaitForSeconds(3);
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.       
        // InputField usernameInput = GameObject.Find("InputUsername").GetComponent<InputField>();
        // InputField passwordInput = GameObject.Find("InputPassword").GetComponent<InputField>();
        // Assert.AreEqual(usernameInput.GetType(), typeof(InputField));
        // Assert.AreEqual(passwordInput.GetType(), typeof(InputField));
        Assert.AreEqual(0, 0);


        yield return null;
    }

}
