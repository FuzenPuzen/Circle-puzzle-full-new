using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsLoader : ILoadService
{
    public T LoadItem<T>(string key)
    {
        return JsonConvert.DeserializeObject<T>(PlayerPrefs.GetString(key));
    }

    public void SaveItem<T>(T item, string key)
    {
        string value = JsonConvert.SerializeObject(item);
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }

    public void SaveItems<T>(List<T> items, string key)
    {
        string value = JsonConvert.SerializeObject(items);
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }

    public List<T> LoadItems<T>(string key)
    {
        return JsonConvert.DeserializeObject<List<T>>(PlayerPrefs.GetString(key));
    }

    public T LoadData<T>(T obj, string key) where T : class
    {

        if (!PlayerPrefs.HasKey(key))
        {
            SaveItem(obj, key);
        }
        else
        {
            obj = LoadItem<T>(key);
        }

        return obj;
    }

    public List<T> LoadDatas<T>(List<T> objs, string key)
    {
        if (!PlayerPrefs.HasKey(key))
        {
            SaveItems(objs, key);
        }
        else
        {
            objs = LoadItems<T>(key);
        }

        return objs;
    }
}
