using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;

    public Transform ground;
    public LayerMask groundLayer;        // Ground 레이어 지정
    Vector2 inputVec;
    public bool jumpable = true;
    bool jumpPressed = false;
    SpriteRenderer ren;
    Animator animator;
    public float speed;
    public float jumpRange;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
        ren = GetComponent<SpriteRenderer>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputVec = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.Play("player_jump");
            jumpPressed = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        jumpable = Physics2D.Raycast(ground.position, Vector2.down, 0.12f, groundLayer);

        
        if(inputVec.x < 0)
        {
            animator.SetBool("Walk", true);
            ren.flipX = true;
        }
        else if(inputVec.x > 0)
        {
            animator.SetBool("Walk", true);
            ren.flipX = false;
        }
        else
        {
            animator.SetBool("Walk", false);
        }
        if (!jumpable)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Walk", false);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        if (jumpPressed)
        {
            jump();
            jumpPressed = false;
        }
    }

   
    private void FixedUpdate()
    {
        Vector2 norVec = inputVec.normalized;
        move(norVec);

    }

    void jump()
    {
        if (jumpable)
        {
            rb.AddForce(new Vector2(0, jumpRange), ForceMode2D.Impulse);
            jumpable = false;
        }
    }

    public void Knockback(GameObject kber)
    {
        if (!knockbacked)
        {
            float x = 0;
            if (transform.position.x - kber.transform.position.x >= 0)
            {
                x = 1;
            }
            else
            {
                x = -1;
            }
            rb.linearVelocity = new Vector2(0, 0);

            rb.AddForce(new Vector2(x * 3, 3), ForceMode2D.Impulse);
            jumpable = false;
            StartCoroutine(knockbacklogic());
        }
    }

    public bool knockbacked = false;
    float knockbacktime = 0.2f;
    float knockbacktimenow;
    IEnumerator knockbacklogic()
    {
        jumpable = false;
        knockbacktimenow = knockbacktime;
        while (jumpable == false || knockbacktimenow > 0)
        {
            knockbacked = true;
            knockbacktimenow -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        
        knockbacked = false;
    }

    void move(Vector2 norVec)
    {
        if (!knockbacked)
        {
            rb.linearVelocity = new Vector2(norVec.x * speed, rb.linearVelocity.y);
        }
    }


}
