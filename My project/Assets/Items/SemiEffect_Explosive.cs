using UnityEngine;


[CreateAssetMenu(menuName = "Effect/SemiEffect/Explosive")]
public class SemiEffect_Explosive : SemiEffect{
    public float damage;
    public float Radius;
    public override void Effect(GameObject enemy, GameObject player){
        //폭발
        Debug.Log("퍼펑");
        var hit = Physics2D.OverlapCircleAll(enemy.transform.position, Radius,LayerMask.GetMask("hitable"));
        foreach(var h in hit)
        {
            var a = h.GetComponentInParent<EnemyHealth>();
            if(a != null)
            {
                a.getRawDamage(damage);
            }
        }

    }

    public override string getDesc(){
        return string.Format("폭발하여 범위로 {0}의 대미지를 입힙니다",damage);
    }
}