using UnityEngine;

public class EnemyInventory : MonoBehaviour
{
    public Item item;



    public void Drop()
    {
        if (item != null)
        {
            GameObject o = Instantiate(ItemDatabase.Instance.dropPref, transform.position, Quaternion.identity);
            Item clone = Instantiate(item);
            clone.SetUp();
            o.GetComponent<DroppedItem>().setUp(clone);
        }
    }
    private void OnDestroy()
    {
        Drop();
    }
}
