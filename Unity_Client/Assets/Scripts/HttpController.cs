using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
public class HttpController : MonoBehaviour
{
    private string test;
    public async void GetUser()
    {
        var httpClient = new HttpClient();
        var url = "https://jsonplaceholder.typicode.com/todos/1";

        var result = await httpClient.Get<User>(url);
        test = User.Title.get();
        Debug.Log(test);
    }
}
