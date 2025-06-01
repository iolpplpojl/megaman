using NUnit.Framework.Internal;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/Potions")]

public class Potion : Item
{
    public List<PotionEffect> effects;

    public void Use(GameObject Player)
    {
        foreach (var effect in effects)
        {
            effect.Use(Player);
        }

    }

    public override string getDesc()
    {
        string desc = this.desc + "\n";
        foreach (var e in effects)
        {
            desc += e.getDesc() + "\n";
        }
        return desc;

    }
}
