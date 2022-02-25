using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
public class HttpController : MonoBehaviour
{
    private int test;
    public async void GetUser()
    {
        var httpClient = new HttpClient();
        var url = "https://jsonplaceholder.typicode.com/todos/1";

        var user = await httpClient.Get<User>(url);
        test = user.UserId;
        Debug.Log(test);
    }
}
