using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance;

    public List<Item> item;

    private void Awake()
    {
        Instance = this;
    }

}

[System.Serializable]
public class Item : ScriptableObject
{
    public int id;
    public string itemname;
    public Sprite sprite;
    public float weight;
}

[CreateAssetMenu(menuName = "Items/Equipment")]
public class Equipment : Item
{
    public int health;
    public int armor;

    public List<Effect> effects = new List<Effect>();
    protected List<Effect> cEffect = new List<Effect>();

    public virtual void SetUp(){
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

    public virtual string getDesc()
    {
        string desc = "";
        foreach(var e in cEffect){
            desc += e.getDesc() + "\n";
        } 
        return desc;

    }

}
[CreateAssetMenu(menuName = "Items/Equipment/Weapon")]
public class Weapon : Equipment
{
    public int damage;
    public float range;
    public float speed;


    public virtual void OnHit(GameObject enemy, GameObject player) // 맞은 적 전체 적용
    { 
        foreach(var e in cEffect){
            e.OnHit(enemy, player);
        }
    }
    public virtual void OnAttack(GameObjet enemy, GameObject player) // 맞은 적 하나 (한 공격에 1회) 적용용
    {
        foreach (var e in cEffect){
            e.OnAttack(enemy, player);
        }
    }

}
[CreateAssetMenu(menuName = "Items/Equipment/Helmet")]
public class Helmet : Equipment
{

}
[CreateAssetMenu(menuName = "Items/Equipment/Gloves")]
public class Gloves : Equipment
{

}
[CreateAssetMenu(menuName = "Items/Equipment/Shoes")]
public class Shoes : Equipment
{

}
[CreateAssetMenu(menuName = "Items/Equipment/Chest")]
public class Chest : Equipment
{

}
[CreateAssetMenu(menuName = "Items/Equipment/Pants")]
public class Pants : Equipment
{

}

public class Effect : ScriptableObject {
    public virtual void SetUp(){
    }
    
    public virtual string getDesc(){
        return "";
    }

    public virtual void OnHurt(GameObject player, GameObject enemy){    
        
    }
    public virtual void OnHit(GameObject enemy, GameObject player){

    }
    public virtual void OnAttack(GameObject enemy, GameObject player){

    }
}

public class Effect_HurtHeal : Effect{ // 맞을때 회복

    public float amount;
    public override void OnHurt(GameObject player, GameObject enemy){
        player.heal(amunt);
    }
}

public class Effect_CountsAttack : Effect{ // ?번 공격 적중 성공시 ? 효과
    public int AttackMaxCount = 3;
    public float Damage;
    int AttackCount = 1;

    public List<SemiEffect> effect;
    List<SemiEffect> cEffect = new List<SemiEffect>;
    public virtual void SetUp(){
        foreach(var e in effect){
            cEffect.Add(Instantiate(e));
        }    
    }
    

    public override void OnAttack(GameObject enemy, GameObject player){
        if(AttackCount != AttackMaxCount){
            AttackCount ++;
            return;
        }
        else if( AttackCount == AttackMaxCount )
        {
            Effect(인자, 인자);
            AttackCount = 0;
        }
    }
    public void Effect(GameObject enemy, GameObject player){    
        //터질 효과, 현재로는 enemy.getdamage(50)이어야 함;
        foreach(var e in  cEffect){
            e.Effect(인자, 인자);
        }
    }
    public override string getDesc(){
        return String.Format("{0}번째 공격마다 {1}." , AttackMaxCount, cEffect[0].getDesc());
    }
}


public class SemiEffect{
    public virtual void Effect(GameObject enemy, GameObject player){

    }

    public virtual string getDesc(){
        return "";
    }
}

public class SemiEffect_Explosive : SemiEffect{
    float damage;
    public override void Effect(GameObject enemy, GameObject player){
        //폭발
    }

    public virtual string getDesc(){
        return String.Format("폭발하여 범위로 {0}의 대미지를 입힙니다",damage);
    }
}