using UnityEngine;


[CreateAssetMenu(menuName = "Quests")]
public class Quest : ScriptableObject
{
    int questId;
    public QuestRequire require;
}
