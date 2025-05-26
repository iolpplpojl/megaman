using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform attackpos;
    Vector3 newAttackpos;
    public float attackRadius;
    Animator animator;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        newAttackpos = attackpos.position;
    }

    private void Update()
    {
        if (spriteRenderer.flipX)
        {
            newAttackpos = new Vector3(attackpos.position.x + (attackpos.localPosition.x * -2), attackpos.position.y);
        }
        else
        {
            newAttackpos = attackpos.position;
        }
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Attack");
            animator.Play("player_snap", -1, 0f);
            var hit = Physics2D.OverlapCircleAll(newAttackpos, attackRadius, LayerMask.GetMask("hitable"));
            foreach(var h in hit)
            {
                h.GetComponent<hitable>().hit(transform.gameObject, 32f);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(newAttackpos, attackRadius);

    }
}
