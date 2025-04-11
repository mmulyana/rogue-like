using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public int currentHealth;
    public int maxHealth;

    public float damageInvicLength = 1f;
    public float invicCount;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;

    }

    void Update()
    {
        if(invicCount > 0)
        {
            invicCount -= Time.deltaTime;
            if (invicCount < 0)
            {
                invicCount = 0;
            }
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

                AudioManager.instance.PlayGameOver();
            }
        }
    }

    public void MakeInvicible(float length)
    {
        invicCount = length;
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.instance.healthSlider.value = currentHealth;
    }
}
