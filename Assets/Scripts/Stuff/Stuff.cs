using UnityEngine;

public class Stuff : MonoBehaviour
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minThrowForced;
    [SerializeField] private float maxThrowForced;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float horizontal = Random.Range(-1f, 1f);
        float upForce = Random.Range(minThrowForced, maxThrowForced);

        Vector2 throwDir = new Vector2(horizontal, 1f).normalized;
        float speed = Random.Range(minSpeed, maxSpeed);

        rb.linearVelocity = throwDir * speed + Vector2.up * upForce * 0.5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Basket") || collision.CompareTag("Player"))
        {
            Do();
        }
    }

    protected virtual void Do()
    {

    }

}
