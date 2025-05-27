using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    EnemyDealer delar;

    private void Start()
    {
        delar = GetComponentInParent<EnemyDealer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            delar?.Deal(collision.gameObject);
        }
    }
}
