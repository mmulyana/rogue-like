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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(Player.instance.dashCounter > 0)
            {
                Destroy(gameObject);

                AudioManager.instance.PlaySfx(0);

                int piecesToDrop = Random.Range(1, maxPieces);

                for(int i = 0; i < piecesToDrop; i++)
                {
                    int randomPiece = Random.Range(0, brokenPieces.Length);
                    Instantiate(brokenPieces[randomPiece], transform.position, transform.rotation);
                }
            }

            // drop item
            if(shouldDropItem)
            {
                float dropChange = Random.Range(0f, 100f);
                if(dropChange < itemDropPercent)
                {
                    int random = Random.Range(0, itemToDrop.Length);

                    Instantiate(itemToDrop[random], transform.position, transform.rotation);
                }
            }
        }
    }
}
