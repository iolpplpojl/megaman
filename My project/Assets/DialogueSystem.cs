using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueSystem : MonoBehaviour
{

    public static DialogueSystem instance;

    public static event Action<string> nameRes;
    public GameObject dialobj;

    public GameObject pref;

    public TMP_Text npcname;
    public TMP_Text npctext;
    public GameObject parent;

    public List<DialogueSlot> slots = new List<DialogueSlot>();

    NPC npc;

    bool selecting = false;
    bool telling = false;
    bool choicing = false;


    int idx = -1;
    int lineidx = 0;

    List<DialogueLine> lines = new List<DialogueLine>();
    List<DialogueChoice> choices = new List<DialogueChoice>();
    void Start()
    {
        instance = this;    
    }


    public void SetDialogue(NPC npc)
    {
        this.npc = npc;
        InputManager.instance.input.SwitchCurrentActionMap("UI2");
        dialobj.SetActive(!dialobj.activeSelf);

        npcname.text = npc.npcname;
        npctext.text = npc.greeting[0];
        if(npc.defaultLine != null)
        {
            GameObject o = Instantiate(pref, parent.transform);
            o.GetComponent<DialogueSlot>().setUp(npc.defaultLine.title);
            slots.Add(o.GetComponent<DialogueSlot>());
        }
        if (npc.uniqueDialogue != null)
        {
            int i = 1;
            foreach (var a in npc.uniqueDialogue)
            {
                GameObject o = Instantiate(pref, parent.transform);
                o.GetComponent<DialogueSlot>().setUp(a.title);
                slots.Add(o.GetComponent<DialogueSlot>());
                i++;
            }
        }
        selecting = true;
    }

    public void DoDialogue(Dialogue dial)
    {
        foreach (Transform s in parent.transform)
        {
            Destroy(s.gameObject);
        }
        selecting = false;
        lines = dial.line;
        lineidx = 0;
        NextLine();
    }

    public void NextLine()
    {
        telling = true;
        if(lineidx == lines.Count)
        {
            OffDialogue();
            return;
        }
        npctext.text = lines[lineidx].text;
        Debug.Log(lines[lineidx].text + lineidx);
        if (lines[lineidx].choice.Count != 0)
        {
            Debug.Log("�б⹮");
            SetChoice(lines[lineidx].choice);
        }
        lineidx++;

    }


    public void SetChoice(List<DialogueChoice> choice)
    {
        choices.Clear();
        foreach (Transform s in parent.transform)
        {
            Destroy(s.gameObject);
        }
        slots.Clear();
        foreach (var a in choice)
        {
           GameObject o = Instantiate(pref, parent.transform);
           o.GetComponent<DialogueSlot>().setUp(a.text);
           slots.Add(o.GetComponent<DialogueSlot>());
           choices.Add(a);
        }
        telling = false;
        selecting = true;
        choicing = true;
        idx = -1;
    }
    public void OffDialogue()
    {
        foreach (Transform s in parent.transform)
        {
            Destroy(s.gameObject);
        }
        dialobj.SetActive(false);
        slots.Clear();
        selecting = false;
        telling = false;
        choicing = false;
        InputManager.instance.input.SwitchCurrentActionMap("Player");
        idx = -1;
    }

    public void OnUp(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log(idx);

            if (selecting)
            {
                if(idx > 0)
                {
                    slots[idx].selected = false;
                    idx--;
                    slots[idx].selected = true;
                }
            }
        }
    }

    public void Choice()
    {

    }
    public void OnDown(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log(idx);
            if (selecting)
            {
                if (idx < slots.Count -1)
                {
                    if (idx != -1)
                    {
                        slots[idx].selected = false;
                    }
                    idx++;
                    slots[idx].selected = true;
                }
            }
        }
    }
    public void OnSelect(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (selecting)
            {
                if (!telling)
                {
                    if (idx != -1)
                    {
                        if (!choicing)
                        {
                            if (idx == 0)
                            {
                                DoDialogue(npc.defaultLine);
                            }
                            else
                            {
                                DoDialogue(npc.uniqueDialogue[idx - 1]);
                            }
                        }
                        else
                        {
                            choices[idx].Select();
                            OffDialogue();
                        }
                    }
                }

            }
            else
            {
                if (telling)
                {
                    NextLine();
                }

            }
        }
    }
    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OffDialogue();
        }
    }
}
