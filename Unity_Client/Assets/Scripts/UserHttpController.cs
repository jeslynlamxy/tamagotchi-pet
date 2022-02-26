using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
public class UserHttpController
{
    HttpClient client = new HttpClient();

    public User readUser()
    {
        string url = "https://jsonplaceholder.typicode.com/todos/1";
        HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();
        string responseStr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        Debug.Log(responseStr);
        User user = JsonConvert.DeserializeObject<User>(responseStr);
        return user;
    }

    // public User readUser(string url, string userId){
    //     string urlWithParams = string.Format("{0}?id={1}", url, userId);
    //     HttpResponseMessage response = client.GetAsync(urlWithParams).GetAwaiter().GetResult();
    //     string responseStr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    //     User user = JsonUtility.FromJson<User>(responseStr);
    //     return user;
    // }

    // public string createUser(string url, User newUser) {
    //     var formContent = new StringContent(newUser.ToJSON(), Encoding.UTF8, "application/json");
    //     HttpResponseMessage response = client.PostAsync(url, formContent).GetAwaiter().GetResult();
    //     string responseStr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    //     return responseStr;
    // }

    // public string updateUser(string url, User user){
    //     var formContent = new StringContent(user.ToJSON(), Encoding.UTF8, "application/json");
    //     HttpResponseMessage response = client.PutAsync(url, formContent).GetAwaiter().GetResult();
    //     string responseStr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    //     return responseStr;
    // }

    // public string deleteUser(string url, string userId){
    //     string urlWithParams = string.Format("{0}?id={1}", url, userId);
    //     HttpResponseMessage response = client.DeleteAsync(urlWithParams).GetAwaiter().GetResult();
    //     string responseStr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    //     return responseStr;
    // }
}
