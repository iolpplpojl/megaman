using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public Transform Target;
    Rigidbody2D rb;
    public float find;
    public bool isFind = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Jump());
    }


    float hit = 0.0f;
    public float speed;
    public float jump;
    private void Update()
    {
        var hit = Physics2D.OverlapCircle(transform.position, find, LayerMask.GetMask("player"));
        if (hit != null)
        {
            isFind = true;
        }
    }

    public void Move()
    {
        if (hit <= 0 && isFind == true)
        {
            Vector2 nor = (new Vector2(Target.position.x, 0) - new Vector2(transform.position.x, 0)).normalized;
            rb.linearVelocity = new Vector2((nor * speed).x, rb.linearVelocity.y);
        }
    }

    private void FixedUpdate()
    {
        if (hit > 0)
            hit -= Time.fixedDeltaTime;
    }
    public float hitDelay;
    public void onHit()
    {
        rb.linearVelocityX = 0;
        hit = hitDelay;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, find);
    }
    void doJump()
    {

        rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);

    }
    IEnumerator Jump()
    {
        while (true)
        {
            doJump();
            yield return new WaitForSeconds(10.0f);
        }
    }
}
