using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public static Player instance;

    public Rigidbody2D rb;
    public Animator anim;

    private Camera cam;
    private Vector2 moveInput;

    [Header("Move Info")]
    [SerializeField] private float speedMove;

    [Header("Arm Info")]
    public Transform gunArm;

    [Header("Shoot Info")]
    public GameObject bulletToFire;
    public Transform firePoint;
    public float timeBetweenShots;
    private float shotCounter;

    public GameObject damageEffect;

    private void Awake()
    {
        instance = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerGunMove();
        CheckAnimation();
        PlayerShoot();
    }

    private void PlayerShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
            shotCounter = timeBetweenShots;
        }

        if (Input.GetMouseButton(0))
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
                shotCounter = timeBetweenShots;
            }
        }
    }

    private void CheckAnimation()
    {
        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isMove", true);
        }
        else
        {
            anim.SetBool("isMove", false);
        }
    }

    private void PlayerGunMove()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = cam.WorldToScreenPoint(transform.localPosition);

        if(mousePos.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            gunArm.localScale = new Vector3(-.5f, -.5f, 0.5f);
        } else
        {
            transform.localScale = Vector3.one;
            gunArm.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        // Rotate gun arm
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        gunArm.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void PlayerMove()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        //transform.position += new Vector3(moveInput.x * Time.deltaTime * speedMove, moveInput.y * Time.deltaTime * speedMove, 0f);

        rb.linearVelocity = moveInput * speedMove;
    }
}
