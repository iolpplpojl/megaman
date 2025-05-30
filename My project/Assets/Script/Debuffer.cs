using UnityEngine;

public class Debuffer : MonoBehaviour
{
    public Health Owner_health;
    public IStat Owner_stat;


    void Awake(){
        Owner_health = GetComponent<Health>();
        Owner_stat = GetComponent<IStat>();
    }



    IEnumerator reduceArmor(float point, float time){
        Owner_stat.Armor -= point;
        yield return new WaitForSeconds(time);
        Owner_stat.Armor += point;
    }

    IEnumerator Bleed(float time, float damage){
        int count = Mathf.CeilToInt(time * 60); // 60번 반복 (예: time=1초 -> 60번)

        for(int i = 0; i < count; i++){
            Owner_health.getDamage(damage/60f);
            yield return new WaitForFixedUpdate();
        }

    }
}



public interface IStat
{
    public float MaxHealth { get; set;}
    public float Armor { get; set;}
    public float Speed { get; set;}
}