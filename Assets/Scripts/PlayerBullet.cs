using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Effect Info")]
    public GameObject impactEffect;

    [Header("Bullet Info")]
    public float speed = 8f;
    public int damage = 50;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = transform.right * speed;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);

        if(other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().DamageEnemy(damage);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
