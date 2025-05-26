using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public Transform Target;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    float hit = 0.0f;
    public float speed;
    private void Update()
    {
        if (hit <= 0)
        {
            Vector2 nor = (new Vector2(Target.position.x, 0) - new Vector2(transform.position.x, 0)).normalized;
            rb.linearVelocity = (nor * speed);
        }
        else
        {
            hit -= Time.fixedDeltaTime;
        }
    }

    public float hitDelay;
    public void onHit()
    {
        rb.linearVelocityX = 0;
        hit = hitDelay;
    }
}
