using UnityEngine;

public interface Health
{
    public float Health {  get; set; }
    void getDamage(float Damage, GameObject attacker);
}
