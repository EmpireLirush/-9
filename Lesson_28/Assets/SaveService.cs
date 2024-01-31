using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveService : MonoBehaviour
{
    private string _filePath;
    
    public LevelSaveData SaveData { get; private set; }

    private void OnEnable()
    {
        _filePath = Application.persistentDataPath + "/Save.json";
        Load();
    }

    [ContextMenu("Save")]
    public void Save()
    {
        using (FileStream file = File.Create(_filePath))
        {
            new BinaryFormatter().Serialize(file, SaveData);
        }
    }

    [ContextMenu("Load")]
    public void Load()
    {
        using (FileStream file = File.Open(_filePath, FileMode.Open))
        {
            object loadedData = new BinaryFormatter().Deserialize(file);
            SaveData = (LevelSaveData)loadedData;
        }
    }
}

[Serializable]
public class LevelSaveData
{
    public Dictionary<string, SaveData> _data = new Dictionary<string, SaveData>();

    public void AddData(string id, SaveData data)
    {
        _data.TryAdd(id, data);
    }

    public bool TryGetData<T>(string id, out T data) where T : SaveData
    {
        foreach (SaveData dataList in _data.Values)
        {
            if (dataList.Id == id)
            {
                data = (T)dataList;
                return true;
            }
        }
        data = null;
        return false;
    }
    
    public LevelSaveData()
    {

    }
}

[Serializable]
public class SaveData
{
    public string Id { get; private set; }
    public Type Type { get; private set; }
    

    public SaveData(string id, Type type)
    {
        Id = id;
        Type = type;
    }
}

[Serializable]
public class Vector3Serialize
{
    public float X { get; private set; }
    public float Y { get; private set; }
    public float Z { get; private set; }
    
    
    public Vector3Serialize(Vector3 vector)
    {
        X = vector.x;
        Y = vector.y;
        Z = vector.z;
    }

    public Vector3 ToVector()
    {
        return new Vector3(X,Y,Z);
    }
}
