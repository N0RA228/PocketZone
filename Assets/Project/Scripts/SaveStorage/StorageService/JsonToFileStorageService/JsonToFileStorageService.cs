using System;
using System.IO;
using UnityEngine;

public class JsonToFileStorageService : IStorageService
{
    private bool _isInProgressNow;

    public void Save(string key, object data, Action<bool> callback = null)
    {
        if(!_isInProgressNow)
        {
            SaveAsync(key, data, callback);
        }
        else
        {
            callback?.Invoke(false);
        }
    }

    public void Load<T>(string key, Action<T> callback)
    {
        string path = BuildPatch(key);

        if (!File.Exists(path))
        {
            callback?.Invoke(default);
            return;
        }

        using (var fileStream = new StreamReader(path))
        {
            var json = fileStream.ReadToEnd();
            var data = JsonUtility.FromJson<T>(json); 

            callback?.Invoke(data);
        }
    }

    private async void SaveAsync(string key, object data, Action<bool> callback)
    {
        string path = BuildPatch(key);
        string json = JsonUtility.ToJson(data);

        _isInProgressNow = true;

        using (var fileStream = new StreamWriter(path))
        {
            await fileStream.WriteAsync(json);
        }

        _isInProgressNow = false;

        callback?.Invoke(true);
    }

    public string BuildPatch(string key)
    {
        return Path.Combine(Application.persistentDataPath, key);
    }

    public void DeleteSave (string key)
    {
        File.Delete(BuildPatch(key));
    }
}
