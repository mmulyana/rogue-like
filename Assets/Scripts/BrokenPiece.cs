using UnityEngine;

public class BrokenPiece : MonoBehaviour
{
    public SpriteRenderer sr;
    public float fadeSpeed;

    public float speed = 5f;
    private Vector3 moveDirection;

    public float deceleration = 5f;
    public float lifeTime = 3f;

    void Start()
    {
        sr = transform.GetComponent<SpriteRenderer>();

        moveDirection.x = Random.Range(-speed, speed);
        moveDirection.y = Random.Range(-speed, speed);
    }

    void Update()
    {
        transform.position += moveDirection * Time.deltaTime;

        moveDirection = Vector3.Lerp(moveDirection, Vector3.zero, deceleration * Time.deltaTime);

        lifeTime -= Time.deltaTime;

        if(lifeTime < 0)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, Mathf.MoveTowards(sr.color.a, 0f, fadeSpeed * Time.deltaTime));

            if(sr.color.a == 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
