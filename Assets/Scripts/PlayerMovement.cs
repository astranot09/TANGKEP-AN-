using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Walk")]
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] Vector2 dir;
    [SerializeField] Vector2 lastDir;

    [Header("GroundCheck")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private bool isGrounded;



    [Header("Jump")]
    [SerializeField] private float jumpForced = 10f;

    [Header("Animation")]
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void OnMove(InputAction.CallbackContext ctx)
    {
        dir = ctx.ReadValue<Vector2>();
        if (dir.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (dir.x > 0)
        {
            spriteRenderer.flipX = false;
        }


        if (ctx.canceled)
        {
            lastDir = dir;
        }
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && isGrounded)
        {
            rb.linearVelocityY = jumpForced;
        }
        else
        {
            return;
        }
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dir.normalized.x * moveSpeed, rb.linearVelocityY);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        animator.SetFloat("velocityX", Mathf.Abs(rb.linearVelocityX));
        animator.SetFloat("velocityY", rb.linearVelocityY);
    }
}
