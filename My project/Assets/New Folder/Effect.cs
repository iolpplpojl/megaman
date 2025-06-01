using UnityEngine;

[CreateAssetMenu(menuName = "Effect")]
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
