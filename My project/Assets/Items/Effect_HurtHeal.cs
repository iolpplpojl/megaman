using UnityEngine;

[CreateAssetMenu(menuName = "Effect/HurtHeal")]
public class Effect_HurtHeal : Effect{ // 맞을때 회복

    public float amount;
    public override void OnHurt(GameObject player, GameObject enemy){
        player.GetComponent<PlayerHealth>().Heal(amount);
    }
}