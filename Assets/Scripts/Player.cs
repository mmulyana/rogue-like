using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public GameObject bulletToFire;
    public Transform firePoint;
    public Rigidbody2D rb;
    public Animator anim;
    private Camera cam;

    [Header("Move Info")]
    [SerializeField] private float speedMove;

    [Header("Arm Info")]
    public Transform gunArm;

    private Vector2 moveInput;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerGunMove();
        CheckAnimation();

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
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
