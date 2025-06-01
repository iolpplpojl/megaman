using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public static PlayerEquipment instance;
    public Weapon weapon;
    public Helmet helmet;
    public Gloves gloves;
    public Pants pants;
    public Chest chest;
    public Shoes shoes;


    private void Awake()
    {
        instance = this;
    }


public void Equip(Equipment item)
{
    Equipment clonedItem = Instantiate(item); // 장비 복제
    clonedItem.SetUp();
    if (clonedItem is Weapon)
    {
        weapon = (Weapon)clonedItem;
    }
    else if (clonedItem is Helmet)
    {
        helmet = (Helmet)clonedItem;
    }
    else if (clonedItem is Gloves)
    {
        gloves = (Gloves)clonedItem;
    }
    else if (clonedItem is Pants)
    {
        pants = (Pants)clonedItem;
    }
    else if (clonedItem is Chest)
    {
        chest = (Chest)clonedItem;
    }
    else if (clonedItem is Shoes)
    {
        shoes = (Shoes)clonedItem;
    }

    PlayerStat.instance.getStatChange();
}

    public void UnEquip(int idx){
        switch(idx)
        {
            case 0:
                InventorySystem.instance.getItem(helmet);
                helmet = null;
                break;
            case 1:
                InventorySystem.instance.getItem(gloves);
                gloves = null;
                break;
            case 2:
                InventorySystem.instance.getItem(pants);
                pants = null;
                break;
            case 3:
                InventorySystem.instance.getItem(chest);
                chest = null;
                break;
            case 4:
                InventorySystem.instance.getItem(shoes);
                shoes =  null; 
                break;
            case 5:
                InventorySystem.instance.getItem(weapon);
                weapon = null;
                break;

        }
        PlayerStat.instance.getStatChange();
    }
    public List<Equipment> GetAllEquipped()
    {
        List<Equipment> equipped = new List<Equipment>();

        if (weapon != null) equipped.Add(weapon);
        if (helmet != null) equipped.Add(helmet);
        if (gloves != null) equipped.Add(gloves);
        if (pants != null) equipped.Add(pants);
        if (chest != null) equipped.Add(chest);
        if (shoes != null) equipped.Add(shoes);

        return equipped;
    }
}
