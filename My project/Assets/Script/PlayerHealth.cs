using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, Health
{
    public float health;
    public float Health { get => health; set => health = value; }

    public static event Action<float> HealthChanged;


    // Start is called once before the first execution of Update after the MonoBehaviour is created


    


    PlayerMovement rb;

    private void Start()
    {
        rb = GetComponent<PlayerMovement>();
    }
    public void getDamage(float Damage, GameObject attacker)
    {

        triggerOnHurt(Damage,attacker);
        Health -= (Damage - PlayerStat.instance.armor);

        rb.Knockback(attacker);

        HealthChanged?.Invoke(Health);
        if(Health < 0)
        {
            Destroy(gameObject);
        }
        
    }

    public void getRawDamage(float Damage)
    {
        Health -= (Damage - PlayerStat.instance.armor);
        HealthChanged?.Invoke(Health);

        if (Health < 0)
        {
            Destroy(gameObject);
        }
    }
    public void Heal(float amount)
    {
        health += amount;
        if(health > PlayerStat.instance.maxHealth)
        {
            health = PlayerStat.instance.maxHealth;
        }
        HealthChanged?.Invoke(Health);

    }
    public void triggerOnHurt(float Damage, GameObject attacker)
    {
        List<Equipment> e = PlayerEquipment.instance.GetAllEquipped();
        foreach(var a in e)
        {
            a.OnHurt(gameObject,attacker);
        }
    }


}
