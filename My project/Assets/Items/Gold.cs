using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Gold")]
public class Gold : Item
{
    public int amount;
    public void getGold(){
        GoldSystem.instance.getGold(amount);
    }
}