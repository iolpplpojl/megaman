using UnityEngine;

[CreateAssetMenu(menuName = "NPC/DialogueChoice")]
public class DialogueChoice : ScriptableObject
{

    public string text;
    public virtual void Select()
    {
        Debug.Log(text);
    }
}
