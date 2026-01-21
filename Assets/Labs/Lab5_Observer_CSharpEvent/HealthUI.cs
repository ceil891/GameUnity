using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI hpText;

    public int maxHP = 100;
    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
        UpdateHPUI();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHPUI();
    }

    void UpdateHPUI()
    {
        hpText.text = $"HP: {currentHP}";

        float percent = (float)currentHP / maxHP;

        if (percent > 0.6f)
            hpText.color = Color.green;
        else if (percent > 0.3f)
            hpText.color = Color.yellow;
        else
            hpText.color = Color.red;
    }
}
