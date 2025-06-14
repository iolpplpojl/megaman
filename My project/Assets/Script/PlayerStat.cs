using UnityEngine;

public class PlayerStat : MonoBehaviour,IStat
{
    public static PlayerStat instance;

    public float damage;
    public float range;
    public float atkspeed;

    public float maxHealth;
    public float armor;
    public float speed;

    public float basicDamage;
    public float basicSpeed;
    public float basicHealth;

    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float Armor { get => armor; set => armor = value; }
    public float Speed { get => speed; set => speed = value; }
    
    private void Awake(){
        instance = this;
    }
    void Start()
    {
        getStatChange();

    }
    public void getStatChange(){
        PlayerEquipment p = PlayerEquipment.instance;
        var pw = p.weapon;
        var ph = p.helmet;
        var pg = p.gloves;
        var pp = p.pants;
        var pc = p.chest;
        var ps = p.shoes;

        damage = basicDamage + (pw != null ? pw.damage : 0);
        range = (pw != null ? pw.range : 0f);
        atkspeed = (pw != null ? pw.speed : 1f);

        maxHealth = basicHealth
            + (pw != null ? pw.health : 0) 
            + (ph != null ? ph.health : 0) 
            + (pg != null ? pg.health : 0) 
            + (pp != null ? pp.health : 0) 
            + (pc != null ? pc.health : 0) 
            + (ps != null ? ps.health : 0);

        armor = 0 
            + (pw != null ? pw.armor : 0) 
            + (ph != null ? ph.armor : 0) 
            + (pg != null ? pg.armor : 0) 
            + (pp != null ? pp.armor : 0) 
            + (pc != null ? pc.armor : 0) 
            + (ps != null ? ps.armor : 0);

        speed = basicSpeed;

    }


}