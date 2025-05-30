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

    public void getItem(Item item)
    {
        Item i = Instantiate(item);
        i.SetUp();
        inventory.items.Add(i);    
    }
}


[System.Serializable]
public class Inventory
{
    public List<Item> items;
    public float max_weight;
}

