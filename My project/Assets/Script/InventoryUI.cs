using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    public void OnOpen(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InputManager.instance.input.SwitchCurrentActionMap(!inventory.activeSelf == true ? "UI1" : "Player");
            inventory.SetActive(!inventory.activeSelf);
            ResetUI();
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

            Slot slot;
            if (isEquip)
            {
                slot = equipSlots[idx];
            }
            else
            {
                slot = item[idx];
            }
            Debug.Log(slot);
        }
    }
    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.started)
        {
        }
    }



}
