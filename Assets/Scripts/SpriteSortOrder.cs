using UnityEngine;

public class SpriteSortOrder : MonoBehaviour
{
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        sr.sortingOrder = Mathf.RoundToInt(transform.position.y * -10f);
    }

    void Update()
    {
        
    }
}
