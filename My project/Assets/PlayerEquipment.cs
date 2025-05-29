using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public static PlayerEquipment Instance;
    public Weapon weapon;
    public Helmet helmet;
    public Gloves gloves;
    public Pants pants;
    public Chest chest;
    public Shoes shoes;


    private void Awake()
    {
        Instance = this;
    }

    public void Equip(Equipment item)
    {
        if(item as Weapon)
        {
            weapon = (Weapon)item;
        }
        if(item as Helmet)
        {
            helmet = (Helmet)item;
        }
        if( item as Gloves)
        {
            gloves = (Gloves)item;
        }
        if (item as Pants)
        {
            pants = (Pants)item;
        }
        if(item as Chest)
        {
            chest = (Chest)item;
        }
        if(item as Shoes)
        {
            shoes = (Shoes)item;
        }

    }
}
