using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerHealth.instance.DamagePlayer();
            Instantiate(Player.instance.damageEffect, Player.instance.transform.position, Player.instance.transform.rotation);
        }
    }
}
