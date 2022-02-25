using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
public class HttpClient
{
    public async Task<TResultType> Get<TResultType>(string url)
    {
        using var www = UnityWebRequest.Get(url);

        www.SetRequestHeader("Content-Type", "application/json");

        var operation = www.SendWebRequest();

        while (!operation.isDone)
            await Task.Yield();

        var jsonResponse = www.downloadHandler.text;


        if (www.result != UnityWebRequest.Result.Success)
            Debug.Log($"Failed: {www.error}");

        try
        {
            var result = JsonConvert.DeserializeObject<TResultType>(jsonResponse);
            Debug.Log($"Sucess: {www.downloadHandler.text}");
            return result;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Could not parse response {jsonResponse}");
            return default(TResultType);
        }
    }
}
