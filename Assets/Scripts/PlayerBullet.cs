using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed = 8f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = transform.right * speed;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
