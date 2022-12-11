using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class RequestManager : MonoBehaviour
{
    public static RequestManager Instance { get; private set; }
    [SerializeField] private string _url = "https://jsonplaceholder.typicode.com/todos/1";
    [SerializeField] private string _key = "secure";

    private void Awake()
    {
        if (!ReferenceEquals(Instance, null) && !ReferenceEquals(Instance, this))
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    [ContextMenu("Connection Test")]
    public async void ConnectionTest()
    {
        var result = await Get<User>(_url);
        Debug.Log(result.title);
    }

    public async Task<T> Get<T>(string url)
    {
        try
        {
            using var www = UnityWebRequest.Get(url);

            www.SetRequestHeader("Content-Type", "application/json");
            var operation = www.SendWebRequest();

            while (!operation.isDone) await Task.Yield();
            if (www.result != UnityWebRequest.Result.Success) Debug.LogError($"Failed: {www.error}");

            Debug.Log(www.downloadHandler.text);
            return JsonUtility.FromJson<T>(www.downloadHandler.text);
        }
        catch (Exception ex)
        {
            Debug.LogError($"{nameof(Get)} failed: {ex.Message}");
            return default;
        }
    }
}