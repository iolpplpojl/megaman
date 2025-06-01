using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item
{
    public int health;
    public int armor;

    public List<Effect> effects = new List<Effect>();
    protected List<Effect> cEffect = new List<Effect>();

    public override void SetUp(){
        foreach( var e in effects){
            Effect ee = Instantiate(e);
            ee.SetUp();
            cEffect.Add(ee);
        }
    }


    public virtual void OnHurt(GameObject player, GameObject enemy) // 피해를 입었을 때
    {
        foreach(var e in cEffect){
            e.OnHurt(player, enemy);
        }
    }
    public virtual void OnSkill(GameObject player)
    {
        
    }

    public override string getDesc()
    {
        string desc = this.desc + "\n";
        foreach(var e in cEffect){
            desc += e.getDesc() + "\n";
        } 
        return desc;

    }

}
