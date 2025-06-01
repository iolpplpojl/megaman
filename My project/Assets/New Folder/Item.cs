using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Items/")]
public class Item : ScriptableObject
{
    public int id;
    public string itemname;
    public Sprite sprite;
    public float weight;
    public string desc;
    
    public virtual void SetUp()
    {

    }
    public virtual string getDesc()
    {
        return desc;
    }

    public virtual void Use()
    {

    }
}
