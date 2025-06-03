using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "QuestRequire")]

public class QuestRequire : ScriptableObject
{
    public Require req;
    public int id;
    public List<int> firstQuest;
    public int needamount;
}