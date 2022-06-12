using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    private static GameData instance;
    public static GameData Instance 
    {
        get
        {
            if (instance == null)
            {
                instance = new GameData();
                instance.CountData = new Dictionary<int, int>();
            }
            return instance;
        }
    }
    private GameData() { }
    public Dictionary<int,int> CountData { get; private set; }
    public float GameTime { get=> Time.time; }
    public void SetCount(int id,int count = 1)
    {
        if (!CountData.ContainsKey(id))
        {
            CountData.Add(id, count);
        }
        else
        {
            CountData[id] += count;
        }
    }
    public void ResetData()
    {
        CountData.Clear();
    }
}
