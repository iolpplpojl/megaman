using UnityEngine;

public class EnemyStat : MonoBehaviour, IStat
{
    public float maxHealth;
    public float armor;
    public float speed;

    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float Armor { get => armor; set => armor = value; }
    public float Speed { get => speed; set => speed = value; }
}