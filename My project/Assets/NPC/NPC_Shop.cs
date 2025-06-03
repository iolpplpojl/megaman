using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "NPC/Shop")]
public class NPC_Shop : NPC
{
    public Shop shop;
    
}


[System.Serializable]
public class Shop
{
    public List<Stock> item;
}

[System.Serializable]
public class Stock 
{
    public int value;
    public Item item;
}
