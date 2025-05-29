using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{

    public static InventorySystem instance;
    public Inventory inventory;
    private void Awake()
    {
        instance = this;
    }

}


[System.Serializable]
public class Inventory
{
    public List<Item> items;
    public float max_weight;
}

