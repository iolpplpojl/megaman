using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "NPC/Basic")]
public class NPC : ScriptableObject
{
    public List<string> greeting;
    public List<Dialogue> dialogue;
    public List<Quest> quest;
    public virtual void setUp()
    {

    }
    public virtual void execute()
    {
        
    }
}

[System.Serializable]
public class Dialogue
{
    public string title;
    public int id;
    public List<string> text;
}
