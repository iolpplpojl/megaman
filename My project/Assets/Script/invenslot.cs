using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class invenslot : Slot
{
    public Item item;

    public Image icon;
    public TMP_Text itemname;

    public void doReset()
    {
        if (item)
        {
            icon.sprite = item.sprite;
            itemname.text = item.itemname;
        }
    }
}
