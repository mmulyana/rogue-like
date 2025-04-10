using UnityEngine;

public class DeathSplaterController : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3f); 
    }
}
