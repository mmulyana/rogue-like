using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    private Vector3 direction;

    void Start()
    {
        direction = Player.instance.transform.position - transform.position;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);

        if(other.tag == "Player")
        {
            PlayerHealth.instance.DamagePlayer();
            Instantiate(Player.instance.damageEffect, Player.instance.transform.position, Player.instance.transform.rotation);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
