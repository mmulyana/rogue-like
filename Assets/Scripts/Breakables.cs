using UnityEngine;

public class Breakables : MonoBehaviour
{
    [Header("Pieces Info")]
    public GameObject[] brokenPieces;
    public int maxPieces;

    public bool shouldDropItem;
    public GameObject[] itemToDrop;
    public float itemDropPercent;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Smash()
    {
        Destroy(gameObject);

        AudioManager.instance.PlaySfx(0);

        //show broken pieces
        int piecesToDrop = Random.Range(1, maxPieces);

        for (int i = 0; i < piecesToDrop; i++)
        {
            int randomPiece = Random.Range(0, brokenPieces.Length);

            Instantiate(brokenPieces[randomPiece], transform.position, transform.rotation);
        }

        //drop items
        if (shouldDropItem)
        {
            float dropChance = Random.Range(0f, 100f);

            if (dropChance < itemDropPercent)
            {
                int randomItem = Random.Range(0, itemToDrop.Length);

                Instantiate(itemToDrop[randomItem], transform.position, transform.rotation);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Smash();
        }

        if(other.tag == "PlayerBullet")
        {
            Smash();
        }
    }
}
