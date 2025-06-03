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
            newAttackpos = new Vector3(attackpos.position.x + (attackpos.localPosition.x * -2) - range/2, attackpos.position.y);
        }
        else
        {
            newAttackpos = attackpos.position + new Vector3(range/2, 0);
        }
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Attack");
            animator.Play("player_snap", -1, 0f);
            var hit = Physics2D.OverlapCapsuleAll(
                    newAttackpos,
                    new Vector2(attackRadius + PlayerStat.instance.range, attackRadius),
                    CapsuleDirection2D.Horizontal,
                    0f,
                    LayerMask.GetMask("hitable")
                );

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
        float range = Application.isPlaying ? PlayerStat.instance.range : 0f;
        Vector2 center = Application.isPlaying ? newAttackpos : (Vector2)attackpos.position;
        float width = attackRadius + range;
        float height = attackRadius;

    // 타원형(가로 캡슐 형태)을 사각형과 반원 두 개로 근사적으로 표현
    Gizmos.DrawWireCube(center, new Vector3(width, height, 0));


    }
}
