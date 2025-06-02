using UnityEngine;

[CreateAssetMenu(menuName = "PotionEffect/")]
public class PotionEffect : ScriptableObject
{

    public virtual void Use(GameObject Player)
    {

    }
    public virtual string getDesc()
    {
        return "";
    }
}
