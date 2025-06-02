using UnityEngine;

[CreateAssetMenu(menuName = "Items/Equipment/Weapon")]
public class Weapon : Equipment
{
    public int damage;
    public float range;
    public float speed;


    public virtual void OnHit(GameObject enemy, GameObject player) // 맞은 적 전체 적용
    {
        foreach (var e in cEffect)
        {
            e.OnHit(enemy, player);
        }
    }
    public virtual void OnAttack(GameObject enemy, GameObject player) // 맞은 적 하나 (한 공격에 1회) 적용용
    {
        foreach (var e in cEffect)
        {
            e.OnAttack(enemy, player);
        }
    }

}
