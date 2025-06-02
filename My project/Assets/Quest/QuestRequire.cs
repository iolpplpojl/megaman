using UnityEngine;


[CreateAssetMenu(menuName = "QuestRequire")]

public class QuestRequire : ScriptableObject
{
    public Require req;
    public int id;
    public int needamount;
}