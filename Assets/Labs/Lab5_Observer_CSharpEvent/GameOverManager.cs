using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject gameOverUI;

    private void OnEnable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnDeath += ShowGameOver;
        }
    }

    private void OnDisable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnDeath -= ShowGameOver;
        }
    }

    private void ShowGameOver()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        Time.timeScale = 0f; // pause game
    }
}