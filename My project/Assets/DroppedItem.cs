using UnityEngine;


public class DroppedItem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Rigidbody2D rb;
    public Item item;
    public SpriteRenderer spriteRenderer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-1,1f), Random.Range(2f,4f)),ForceMode2D.Impulse);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void setUp(Item item)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.item = item;
        spriteRenderer.sprite = this.item.sprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InventorySystem.instance.getItem(item);

            Destroy(gameObject);
            Debug.Log("zz");
        }

    }

}
