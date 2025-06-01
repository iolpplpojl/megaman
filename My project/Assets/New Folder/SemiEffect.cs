using UnityEngine;

[CreateAssetMenu(menuName = "Effect/SemiEffect")]

public class SemiEffect : ScriptableObject{
    public virtual void Effect(GameObject enemy, GameObject player){

    }

    public virtual string getDesc(){
        return "";
    }
}