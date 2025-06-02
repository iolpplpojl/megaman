using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour,Health
{
    public float health;
    public float Health { get => health; set => health = value; }

    public static event Action<int> DeathSignal;



    public void getRawDamage(float Damage)
    {
        Health -= (Damage - PlayerStat.instance.armor);
        if (Health < 0)
        {

            die();
        }
    }
    void die()
    {
        var o = GetComponent<EnemyInventory>();
        if (o != null)
        {
            o.Drop();
            
        }
        DeathSignal?.Invoke(GetComponent<EnemyStat>().id);
        Destroy(gameObject);


    }
    public void getDamage(float Damage, GameObject attacker)
    {
        Health -= Damage;

        EnemyMover mov = GetComponent<EnemyMover>();

        if(mov != null)
        {
            mov.onHit();
        }

        if (Health < 0)
        {
            die();
        };
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
