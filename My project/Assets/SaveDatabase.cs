using System.Collections.Generic;
using UnityEngine;

public class SaveDatabase : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public static SaveDatabase instance;
    public SaveData data;
    void Start()
    {
        instance = this;
    }


}


[System.Serializable]
public class SaveData
{
    public List<int> progressId;
}

