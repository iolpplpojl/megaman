using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UI;
public class EquipSlot : Slot
{
    public EQIUPPOS pos;

    Image sprite;

    private void Awake()
    {
        sprite = GetComponent<Image>();
    }


    private void Update()
    {
        Equipment equipment = pos switch
        {
            EQIUPPOS.helmet => PlayerEquipment.Instance?.helmet,
            EQIUPPOS.chest => PlayerEquipment.Instance?.chest,
            EQIUPPOS.gloves => PlayerEquipment.Instance?.gloves,
            EQIUPPOS.pants => PlayerEquipment.Instance?.pants,
            EQIUPPOS.shoes => PlayerEquipment.Instance?.shoes,
            EQIUPPOS.weapon => PlayerEquipment.Instance?.weapon,
            _ => null
        };

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