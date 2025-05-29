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
        float range = PlayerEquipment.Instance?.weapon?.range ?? 0f;
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

           float range = PlayerEquipment.Instance?.weapon?.range ?? 0f;

            Debug.Log("Attack");
            animator.Play("player_snap", -1, 0f);
            var hit = Physics2D.OverlapCircleAll(newAttackpos, attackRadius + PlayerEquipment.Instance.weapon?.range ?? 0f, LayerMask.GetMask("hitable"));
            foreach(var h in hit)
            {
                h.GetComponent<hitable>().hit(transform.gameObject, 2f + PlayerEquipment.Instance.weapon?.damage ?? 0f);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float range = PlayerEquipment.Instance?.weapon?.range ?? 0f;
        Gizmos.DrawWireSphere(newAttackpos, attackRadius + range);

    }
}
