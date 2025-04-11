using UnityEngine;

public class Breakables : MonoBehaviour
{
    [Header("Pieces Info")]
    public GameObject[] brokenPieces;
    public int maxPieces;

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

                int piecesToDrop = Random.Range(1, maxPieces);

                for(int i = 0; i < piecesToDrop; i++)
                {
                    int randomPiece = Random.Range(0, brokenPieces.Length);
                    Instantiate(brokenPieces[randomPiece], transform.position, transform.rotation);
                }
            }
        }
    }
}
