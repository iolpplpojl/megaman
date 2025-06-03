using UnityEngine;

public class EquipTest : MonoBehaviour
{
    public Equipment item;

    public void Equip()
    {
        PlayerEquipment.instance.Equip(item);
        InventorySystem.instance.getItem(item);

    }
}
