using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using YG;

public interface ILoadService
{
    public T LoadData<T>(T obj, string key) where T : class;

    public List<T> LoadDatas<T>(List<T> objs, string key);
    public void SaveItem<T>(T item, string key);
}

public class YSaveService : ILoadService
{
    public YSaveService()
    {
        YandexGame.LoadCloud();
    }

    public T LoadItem<T>(string key)
    {
        
        var data = YandexGame.savesData.SavedItems[key];
        return JsonConvert.DeserializeObject<T>(data);
    }

    public void SaveItem<T>(T item, string key)
    {
        string value = JsonConvert.SerializeObject(item);
        if(YandexGame.savesData.SavedItems.ContainsKey(key))
            YandexGame.savesData.SavedItems[key] = value;
        else
            YandexGame.savesData.SavedItems.Add(key, value);
    }

    public List<T> LoadItems<T>(string key)
    {
        var data = YandexGame.savesData.SavedItems[key];
        return JsonConvert.DeserializeObject<List<T>>(data);
    }

    public T LoadData<T>(T obj, string key) where T : class
    {

        if (YandexGame.savesData.SavedItems.ContainsKey(key))
        {
            obj = LoadItem<T>(key);
        }
        else
        {           
            SaveItem(obj, key);
        }

        return obj;
    }

    public List<T> LoadDatas<T>(List<T> objs, string key)
    {
        if (YandexGame.savesData.SavedItems.ContainsKey(key))
        {
            objs = LoadItems<T>(key);
        }
        else
        {
            SaveItem(objs, key);
        }

        return objs;
    }


}
