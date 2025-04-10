using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;

    public float speedMove = 8;
    public float rangeToChasePlayer = 10;
    public GameObject[] deathSplatters;
    public GameObject hitEffect;
    public SpriteRenderer enemyBody;

    private int health = 150;
    private Vector3 moveDirection;

    [Header("Shoot info")]
    public GameObject bullet;
    public Transform firePoint;
    public bool shoudlShoot;
    public float fireRate;
    public float shootRange;

    private float fireCounter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(enemyBody.isVisible && Player.instance.gameObject.activeInHierarchy)
        {
            if (Vector3.Distance(transform.position, Player.instance.transform.position) < rangeToChasePlayer)
            {
                moveDirection = Player.instance.transform.position - transform.position;
            }
            else
            {
                moveDirection = Vector3.zero;
            }

            moveDirection.Normalize();
            rb.linearVelocity = moveDirection * speedMove;

            if (moveDirection != Vector3.zero)
            {
                anim.SetBool("isMove", true);
            }
            else
            {
                anim.SetBool("isMove", false);
            }

            if (shoudlShoot && Vector3.Distance(transform.position, Player.instance.transform.position) < shootRange)
            {
                fireCounter -= Time.deltaTime;
                if (fireCounter <= 0)
                {
                    fireCounter = fireRate;
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                }
            }
        } else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    public void DamageEnemy(int damage)
    {
        health -= damage;

        Instantiate(hitEffect, transform.position, transform.rotation);

        if(health <= 0)
        {
            Destroy(gameObject);

            int random = Random.Range(0, deathSplatters.Length);

            Instantiate(deathSplatters[random], transform.position, transform.rotation);
        }
    }
}
