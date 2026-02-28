using System.Collections;
using UnityEngine;

public class Stuff : MonoBehaviour
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minThrowForced;
    [SerializeField] private float maxThrowForced;

    private Rigidbody2D rb;

    [SerializeField] private float delayTime = 0.2f;
    [SerializeField] private bool canTrigger = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float horizontal = Random.Range(-1f, 1f);
        float upForce = Random.Range(minThrowForced, maxThrowForced);

        Vector2 throwDir = new Vector2(horizontal, 1f).normalized;
        float speed = Random.Range(minSpeed, maxSpeed);

        rb.linearVelocity = throwDir * speed + Vector2.up * upForce * 0.5f;
        StartCoroutine(DelayTrigger());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Basket") && canTrigger)
        {
            Do();
        }
        if (collision.CompareTag("Player"))
        {
            PlayerGet();
        }
    }

    private IEnumerator DelayTrigger()
    {
        yield return new WaitForSeconds(delayTime);
        canTrigger = true;
    }

    protected virtual void Do()
    {

    }
    protected virtual void PlayerGet()
    {

    }

}
