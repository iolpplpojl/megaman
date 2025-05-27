using UnityEngine;

public class PlayerHealth : MonoBehaviour,Health
{
    public float health;
    public float Health { get => health; set => health = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    PlayerMovement rb;

    private void Start()
    {
        rb = GetComponent<PlayerMovement>();
    }
    public void getDamage(float Damage, GameObject attacker)
    {
        Health -= Damage;

        rb.Knockback(attacker);
        if(Health < 0)
        {
            Destroy(gameObject);
        }
    }
}
