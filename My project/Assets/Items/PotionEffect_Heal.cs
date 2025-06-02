using UnityEngine;
[CreateAssetMenu(menuName = "PotionEffect/Heal")]

public class PotionEffect_Heal : PotionEffect
{
    public float amount;

    public override void Use(GameObject Player)
    {
        Player.GetComponent<PlayerHealth>().Heal(amount);
    }
    public override string getDesc()
    {
        return string.Format("ü���� {0} ȸ���մϴ�.", amount);
    }
}
