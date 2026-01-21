using UnityEngine;

public class HealthAudio : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public AudioSource hitSound;
    public AudioSource deathSound;

    private int _lastHealth;

    private void Start()
    {
        if (playerHealth != null)
        {
            _lastHealth = playerHealth.currentHealth;
        }
    }

    private void OnEnable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged += OnHealthChanged;
            playerHealth.OnDeath += OnDeath;
        }
    }

    private void OnDisable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= OnHealthChanged;
            playerHealth.OnDeath -= OnDeath;
        }
    }

    private void OnHealthChanged(int current, int max)
    {
        if (current < _lastHealth && hitSound != null)
        {
            hitSound.Play();
        }

        _lastHealth = current;
    }

    private void OnDeath()
    {
        if (deathSound != null)
        {
            deathSound.Play();
        }
    }
}