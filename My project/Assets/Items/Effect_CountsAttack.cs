
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/CountsAttack")]
public class Effect_CountsAttack : Effect{ // ?번 공격 적중 성공시 ? 효과
    public int AttackMaxCount = 3;
    int AttackCount = 0;

    public List<SemiEffect> effect;
    List<SemiEffect> cEffect = new List<SemiEffect>();

    public override  void SetUp(){
        foreach(var e in effect){
            SemiEffect a = Instantiate(e);
            cEffect.Add(a);
        }    
    }
    
    public override void OnAttack(GameObject enemy, GameObject player){
        if(AttackCount != AttackMaxCount){
            AttackCount ++;
            return;
        }
        else if( AttackCount == AttackMaxCount )
        {
            Effect(enemy, player);
            AttackCount = 0;
        }
    }
    public void Effect(GameObject enemy, GameObject player){    
        //터질 효과, 현재로는 enemy.getdamage(50)이어야 함;
        foreach(var e in  cEffect){
            e.Effect(enemy, player);
        }
    }
    public override string getDesc(){
        string desc = "";
        foreach (var e in cEffect) {
            desc += string.Format("{0}번째 공격마다 {1}. \n", AttackMaxCount, e.getDesc());
        }
        Debug.Log(desc);
        return desc;
    }
}