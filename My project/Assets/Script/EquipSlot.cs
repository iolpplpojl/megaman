using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UI;
public class EquipSlot : Slot
{
    public EQIUPPOS pos;

    public Equipment item;
    Image sprite;

    protected void Awake()
    {
        base.Awake();
        sprite = GetComponent<Image>();
    }


    protected void Update()
    {

        base.Update();

        Equipment equipment = pos switch
        {
            EQIUPPOS.helmet => PlayerEquipment.instance?.helmet,
            EQIUPPOS.chest => PlayerEquipment.instance?.chest,
            EQIUPPOS.gloves => PlayerEquipment.instance?.gloves,
            EQIUPPOS.pants => PlayerEquipment.instance?.pants,
            EQIUPPOS.shoes => PlayerEquipment.instance?.shoes,
            EQIUPPOS.weapon => PlayerEquipment.instance?.weapon,
            _ => null
        };

        if (equipment != null)
        {
            item = equipment;
        }
        sprite.sprite = equipment?.sprite;
    }
}

public enum EQIUPPOS
{
    helmet,
    chest,
    gloves,
    pants,
    shoes,
    weapon
}