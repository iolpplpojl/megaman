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
        switch(idx){
            case 0:
                weapon = null;
                break; 
            case 1:
                helmet = null;
                break;
            case 2:
                gloves = null;
                break;
            case 3:
                pants = null;
                break;
            case 4: 
                chest = null;
                break;
            case 5: 
                shoes=  null; 
                break;
                
        }
        PlayerStat.instance.getStatChange();
    }
    public List<Equipment> GetAllEquipped()
    {
        return new List<Equipment> { weapon, helmet, gloves, pants, chest, shoes };
    }

}
