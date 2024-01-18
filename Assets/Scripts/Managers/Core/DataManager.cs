using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ILoader<key, Value>
{
    Dictionary<key, Value> MakeDict();
}

public class DataManager 
{
    public Dictionary<int ,Data.Stat> StatDict { get; private set; } = new Dictionary<int, Data.Stat>();
    public Dictionary<int, Data.Item> ItemDict { get; private set; } = new Dictionary<int, Data.Item>();
    public void Init()
    {
        StatDict = LoadJson<Data.StatData, int, Data.Stat>("StatData").MakeDict();
        ItemDict = LoadJson<Data.ItemData, int, Data.Item>("ItemData").MakeDict();
    }

    Loader LoadJson<Loader, key, Value>(string path) where Loader : ILoader<key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");        
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }

    
}
