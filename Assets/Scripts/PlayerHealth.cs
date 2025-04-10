using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public int currentHealth;
    public int maxHealth;

    public float damageInvicLength = 1f;
    private float invicCount;

    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if(invicCount > 0)
        {
            invicCount -= Time.deltaTime;
        }
    }

    public void DamagePlayer()
    {
        if (invicCount <= 0)
        {
            currentHealth--;

            invicCount = damageInvicLength;

            UIController.instance.healthSlider.value = currentHealth;

            if (currentHealth <= 0)
            {
                Player.instance.gameObject.SetActive(false);

                UIController.instance.gameOverScreen.SetActive(true);
            }
        }
    }
}
