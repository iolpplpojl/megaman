using UnityEngine;
public class GoldSystem : MonoBehaviour
{
    public int amount;
    public static GoldSystem instance;

    void Awake(){
        instance = this;
    }



    public void getGold(int gold){
        amount += gold;
    }
    

}
