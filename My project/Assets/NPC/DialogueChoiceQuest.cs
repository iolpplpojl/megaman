using UnityEngine;

[CreateAssetMenu(menuName = "NPC/DialogueChoiceQuest")]
public class DialogueChoice_Quest : DialogueChoice
{
    public Quest quest;


    public override void Select()
    {
        QuestManager.instance.QuestStart(quest);
    }
}