using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class CharacterControllerBase : MonoBehaviour, ICharacterController
{
    protected Rigidbody2D rb;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;

    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float jumpForce = 6f;

    protected bool isGrounded = false;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (animator == null)
            Debug.LogError("❌ Animator NO encontrado en " + gameObject.name);
        else
            Debug.Log("✅ Animator encontrado en " + gameObject.name);
    }

    public virtual void HandleInput()
    {
        float move = Input.GetAxisRaw("Horizontal");

        Vector2 velocity = rb.linearVelocity;
        velocity.x = move * moveSpeed;
        rb.linearVelocity = velocity;

        animator.SetFloat("Speed", Mathf.Abs(move));
        if (move != 0) spriteRenderer.flipX = move < 0;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        animator.SetTrigger("isAttacking");
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    public virtual void Move() { }


    void Update()
    {
        if (animator != null)
        {
            Debug.Log("Estado actual: " + animator.GetCurrentAnimatorStateInfo(0).IsName("RangedWalk"));
        }

    }

}
