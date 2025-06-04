using UnityEngine;

[CreateAssetMenu(menuName = "NPC/DialogueChoice")]
public class DialogueChoice : ScriptableObject
{

    public string text;
    public Dialogue nextDialogue;
    public virtual void Select()
    {
        Debug.Log(text);
    }
}
