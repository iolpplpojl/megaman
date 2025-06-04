using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;



public enum DialogueStatment
{
    select,
    tell,
    choice,
    none,
    endTell,
}
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

    public DialogueStatment state;

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
        state = DialogueStatment.select;
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
                if (a.needQuest.All(r => SaveDatabase.instance.data.progressId.Contains(r)))
                {
                    GameObject o = Instantiate(pref, parent.transform);
                    o.GetComponent<DialogueSlot>().setUp(a.title);
                    slots.Add(o.GetComponent<DialogueSlot>());
                    i++;
                }
            }
        }
    }

    public void DoDialogue(Dialogue dial)
    {
        foreach (Transform s in parent.transform)
        {
            Destroy(s.gameObject);
        }
        lines = dial.line;
        lineidx = 0;
        NextLine();
    }

    public void NextLine()
    {
        state = DialogueStatment.tell;
        npctext.text = lines[lineidx].text;
        Debug.Log(lines[lineidx].text + lineidx);
        if (lines[lineidx].isEndLine)
        {
            state = DialogueStatment.endTell;
        }
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
        state = DialogueStatment.choice;

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
        state = DialogueStatment.none;
        InputManager.instance.input.SwitchCurrentActionMap("Player");
        idx = -1;
    }

    public void OnUp(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log(idx);

            if (state == DialogueStatment.select || state == DialogueStatment.choice)
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
            if (state == DialogueStatment.select || state == DialogueStatment.choice)
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

            if (idx != -1)
            {
                if (state == DialogueStatment.select)
                {
                    if (idx == 0)
                    {
                        DoDialogue(npc.defaultLine);
                        return;
                    }
                    else
                    {
                        DoDialogue(npc.uniqueDialogue[idx - 1]);
                        return;
                    }
                }

                if (state == DialogueStatment.choice)
                {
                    choices[idx].Select();
                    DoDialogue(choices[idx].nextDialogue);
                    return;
                }                
            }

            if (state == DialogueStatment.tell)
            {

                NextLine();
                return;
            }
            if(state == DialogueStatment.endTell)
            {
                OffDialogue();
                return;
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
