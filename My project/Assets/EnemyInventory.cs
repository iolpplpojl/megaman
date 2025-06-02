using System.Collections.Generic;
using UnityEngine;

public class EnemyInventory : MonoBehaviour
{
    public List<Item> item;



    public void Drop()
    {
        foreach (var i in item){
            GameObject o = Instantiate(ItemDatabase.Instance.dropPref, transform.position, Quaternion.identity);
            Item clone = Instantiate(i);
            clone.SetUp();
            o.GetComponent<DroppedItem>().setUp(clone);
        }
    }
}
