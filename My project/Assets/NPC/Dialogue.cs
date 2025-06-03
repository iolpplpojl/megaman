using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "NPC/Dialogue")]

public class Dialogue : ScriptableObject
{
        public List<int> needQuest;
        public string title;
        public List<DialogueLine> line;
}


[System.Serializable]
public class DialogueLine
{
    [TextArea(2, 5)]
    public string text;
    public List<DialogueChoice> choice;
}


