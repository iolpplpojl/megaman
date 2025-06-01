using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public GameObject inventory;
    public PlayerInput playerInput;

    public GameObject parent;
    public GameObject prefab;

    public List<Slot> item;
    public List<EquipSlot> equipSlots;
    public Slot nowSelect;

    bool isEquip = false;
    bool isPopup = false;

    int idx = -1;

    public Image descIcon;
    public TMP_Text descTitle;
    public TMP_Text desc;

    public TMP_Text selectText;


    public GameObject Player;


    public void OnOpen(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InputManager.instance.input.SwitchCurrentActionMap(!inventory.activeSelf == true ? "UI1" : "Player");
            inventory.SetActive(!inventory.activeSelf);
            ResetUI();
        }
    }



    private void Update()

    {
        if (idx != -1)
        {
            if (isEquip)
            {
                if (equipSlots[idx].item != null)
                {
                    descIcon.sprite = equipSlots[idx].item.sprite;
                    descTitle.text = equipSlots[idx].item.itemname;
                    desc.text = equipSlots[idx].item.getDesc();
                    selectText.text = "C : ¹þ±â";
                }
                else
                {

                    selectText.text = "";
                }
            }
            else
            {

                descIcon.sprite = InventorySystem.instance.inventory.items[idx].sprite;
                descTitle.text = InventorySystem.instance.inventory.items[idx].itemname;
                desc.text = InventorySystem.instance.inventory.items[idx].getDesc();
                if (InventorySystem.instance.inventory.items[idx] is Equipment)
                {
                    selectText.text = "C : Âø¿ë";
                }
                else
                {
                    selectText.text = "C : »ç¿ë";
                }

            }
        }
        else
        {
            selectText.text = "";
        }
    
    }


    void ResetUI()
    {
        if (isEquip) {
            equipSlots[idx].selected = false;
            isEquip = false;
        }
        idx = -1;

        List<Item> items = InventorySystem.instance.inventory.items;

        foreach (Transform sons in parent.transform)
        {
            Destroy(sons.gameObject);
        }

        List<Slot> slot = new List<Slot>();
        foreach (var item in items)
        {
            GameObject g = Instantiate(prefab, parent.transform);

            g.GetComponent<invenslot>().item = item;
            g.GetComponent<invenslot>().doReset();

            slot.Add(g.GetComponent<Slot>());
            this.item = slot;
        }
    }

    public void OnUp(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (isEquip)
            {
                if (idx != 0)
                {
                    equipSlots[idx].selected = false;
                    idx--;
                    equipSlots[idx].selected = true;
                }
            }
            else
            {
                if (idx == -1)
                {
                    idx = 0;
                    item[idx].selected = true;
                }
                else if (idx != 0)
                {
                    item[idx].selected = false;
                    idx--;
                    item[idx].selected = true;

                }
            }
        }
    }
    public void OnLeft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!isEquip)
            {
                if (idx != -1)
                {
                    item[idx].selected = false;
                }
                idx = 0;
                equipSlots[idx].selected = true;
                isEquip = true;
                    
            }
        }
    }
    public void OnRight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (isEquip)
            {

                equipSlots[idx].selected = false;
                idx = 0;
                item[idx].selected = true;
                isEquip = false;
            }
        }
    }


    public void OnDown(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (isEquip)
            {
                if(idx != equipSlots.Count - 1)
                {
                    equipSlots[idx].selected = false;
                    idx++;
                    equipSlots[idx].selected = true;
                }
            }
            else
            {
                if (idx != item.Count - 1)
                {
                    if (idx != -1)
                    {
                        item[idx].selected = false;
                    }
                    idx++;
                    item[idx].selected = true;
                }
            }
        }
        
    }
    public void OnSelect(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (idx != -1)
            {
                Slot slot;
                if (isEquip)
                {
                    slot = equipSlots[idx];
                    PlayerEquipment.instance.UnEquip(idx);
                }
                else
                {
                    slot = item[idx];
                    Item it = InventorySystem.instance.inventory.items[idx];
                    if (it is Equipment)
                    {
                        PlayerEquipment.instance.Equip(InventorySystem.instance.inventory.items[idx] as Equipment);
                        InventorySystem.instance.inventory.items.Remove(InventorySystem.instance.inventory.items[idx]);
                    }
                    else if(it is Potion) 
                    {

                        (it as Potion).Use(Player);
                        InventorySystem.instance.inventory.items.Remove(it);

                    }

                }
                Debug.Log(slot);
                ResetUI();
            }
        }
    }
    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.started)
        {
        }
    }



}
