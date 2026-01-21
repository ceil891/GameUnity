using TMPro;
using UnityEngine;

public class PlayerHealthUnityEvent : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public TextMeshProUGUI hpText;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHPUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHPUI();

        if (currentHealth <= 0)
        {
            // OnDeath.Invoke();
        }
    }

    void UpdateHPUI()
    {
        hpText.text = $"HP: {currentHealth}";
    }
}
