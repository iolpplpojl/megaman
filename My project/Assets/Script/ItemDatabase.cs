using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance;

    public List<Item> item;

    public GameObject dropPref;
    private void Awake()
    {
        Instance = this;
    }

}







