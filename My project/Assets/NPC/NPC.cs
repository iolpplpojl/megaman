using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "NPC/Basic")]
public class NPC : ScriptableObject
{
    public string npcname;
    public List<string> greeting;
    public Dialogue defaultLine;
    public List<Dialogue> uniqueDialogue;
    public virtual void setUp()
    {

    }
    public virtual void execute()
    {
        
    }
}



