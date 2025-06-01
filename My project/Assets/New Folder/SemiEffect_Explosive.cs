using UnityEngine;


[CreateAssetMenu(menuName = "Effect/SemiEffect/Explosive")]
public class SemiEffect_Explosive : SemiEffect{
    public float damage;
    public override void Effect(GameObject enemy, GameObject player){
        //폭발
    }

    public override string getDesc(){
        return string.Format("폭발하여 범위로 {0}의 대미지를 입힙니다",damage);
    }
}