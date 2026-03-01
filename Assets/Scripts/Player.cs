using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public float maxHealth = 100;
    public float currHealth = 100;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    //public int extraJumpValue = 1;
    //private int extraJumps;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currHealth = maxHealth;
        //extraJumps = extraJumpValue;
    }

    
    void Update()
    {
        //float moveInput = Input.GetAxis("Horizontal");
        //rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        //if (isGrounded)
        //{
        //    extraJumps = extraJumpValue;
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (isGrounded)
        //    {
        //        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        //    }
        //    else if (extraJumps > 0)
        //    {
        //        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        //        extraJumps--;
        //    }
        //}

        //SetAnimation(moveInput);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            currHealth -= 25;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 10f);
            HealthUI.instance.UpdateHealthUI();
            StartCoroutine(BlinkRed());

            if (currHealth <= 0)
            {
                Die();
            }
        }
    }

    private IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    private void Die()
    {
        Time.timeScale = 0f;
        LosePanel.instance.LoseSetUp();
        //UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
