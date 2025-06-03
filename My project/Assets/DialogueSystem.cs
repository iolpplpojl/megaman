using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{

    public static DialogueSystem instance;

    public static event Action<string> nameRes;
    public GameObject dialobj;

    public GameObject pref;


    void Start()
    {
        instance = this;    
    }


    public void SetDialogue(List<Dialogue> dial)
    {
        InputManager.instance.input.SwitchCurrentActionMap(!dialobj.activeSelf == true ? "UI1" : "Player");
        dialobj.SetActive(!dialobj.activeSelf);

    }

    public void StartDialogue(Dialogue dial)
    {

    }
}
