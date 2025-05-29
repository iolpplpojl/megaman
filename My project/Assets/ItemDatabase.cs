using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance;

    public List<Item> item;

    private void Awake()
    {
        Instance = this;
    }

}

[System.Serializable]
public class Item : ScriptableObject
{
    public int id;
    public string itemname;
    public Sprite sprite;
    public float weight;
}

[CreateAssetMenu(menuName = "Items/Equipment")]
public class Equipment : Item
{
    public int health;
    public int armor;
}
[CreateAssetMenu(menuName = "Items/Equipment/Weapon")]
public class Weapon : Equipment
{
    public int damage;
    public float range;
    public float speed;
}
[CreateAssetMenu(menuName = "Items/Equipment/Helmet")]

public class Helmet : Equipment
{

}
[CreateAssetMenu(menuName = "Items/Equipment/Gloves")]

public class Gloves : Equipment
{

}
[CreateAssetMenu(menuName = "Items/Equipment/Shoes")]

public class Shoes : Equipment
{

}
[CreateAssetMenu(menuName = "Items/Equipment/Chest")]
public class Chest : Equipment
{

}
[CreateAssetMenu(menuName = "Items/Equipment/Pants")]
public class Pants : Equipment
{

}
