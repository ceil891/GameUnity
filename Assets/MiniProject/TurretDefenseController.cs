using UnityEngine;

public class TurretDefenseController : MonoBehaviour
{
    // References for demo
    public Transform turret;
    public Transform target;
    public PlayerHealth playerHealth;

    private void Start()
    {
        // Auto find references if not assigned
        if (playerHealth == null)
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
        }

        if (turret == null)
        {
            GameObject turretGO = GameObject.Find("Turret");
            if (turretGO != null)
            {
                turret = turretGO.transform;
            }
        }

        if (target == null)
        {
            GameObject playerGO = GameObject.Find("Player");
            if (playerGO != null)
            {
                target = playerGO.transform;
            }
        }
    }

    private void Update()
    {
        // Test key để demo health system - Lab 5 requirement
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10);
                Debug.Log("Player took 10 damage. Health: " + playerHealth.currentHealth);
            }
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (playerHealth != null)
            {
                playerHealth.Heal(10);
                Debug.Log("Player healed 10. Health: " + playerHealth.currentHealth);
            }
        }

        // Toggle turret smooth rotation - Lab 3 requirement
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (turret != null)
            {
                TurretController turretController = turret.GetComponent<TurretController>();
                if (turretController != null)
                {
                    turretController.smooth = !turretController.smooth;
                    Debug.Log("Turret smooth mode: " + turretController.smooth);
                }
            }
        }
    }
}