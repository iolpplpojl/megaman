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
        float range =  PlayerStat.instance.range;
        if (spriteRenderer.flipX)
        {
            newAttackpos = new Vector3(attackpos.position.x + (attackpos.localPosition.x * -2) - range, attackpos.position.y);
        }
        else
        {
            newAttackpos = attackpos.position + new Vector3(range, 0);
        }
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Attack");
            animator.Play("player_snap", -1, 0f);
            var hit = Physics2D.OverlapCircleAll(newAttackpos, attackRadius + PlayerStat.instance.range, LayerMask.GetMask("hitable"));
            if (hit.Length != 0)
            {
                PlayerEquipment.instance.weapon?.OnAttack(hit[0].gameObject, gameObject);
            }

            foreach(var h in hit)
            {
                PlayerEquipment.instance.weapon?.OnHit(h.gameObject, gameObject);    
                h.GetComponent<hitable>().hit(transform.gameObject, PlayerStat.instance.damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float range = PlayerStat.instance.range;
        Gizmos.DrawWireSphere(newAttackpos, attackRadius + range);

    }
}
