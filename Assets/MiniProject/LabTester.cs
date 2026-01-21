using UnityEngine;

public class LabTester : MonoBehaviour
{
    // Script để test và demo tất cả các labs một cách có hệ thống

    [Header("Lab References")]
    public GameObject player;
    public GameObject turret;
    public PlayerHealth playerHealth;
    public TurretController turretController;
    public TopdownSignedAngle angleScript;

    private void Start()
    {
        // Auto find references
        FindReferences();
        PrintLabStatus();
    }

    private void FindReferences()
    {
        if (player == null) player = GameObject.Find("Player");
        if (turret == null) turret = GameObject.Find("Turret");

        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
            angleScript = player.GetComponent<TopdownSignedAngle>();
        }

        if (turret != null)
        {
            turretController = turret.GetComponent<TurretController>();
        }
    }

    private void PrintLabStatus()
    {
        Debug.Log("=== LAB STATUS CHECK ===");

        // Lab 1: Lifecycle Logger
        var lifecycleLogger = FindObjectOfType<LifecycleLogger>();
        Debug.Log($"Lab 1 - Lifecycle Logger: {(lifecycleLogger != null ? "✓ FOUND" : "✗ MISSING")}");

        // Lab 2: Vector Movement & Gizmos
        var topDownMover = player?.GetComponent<TopDownMover>();
        Debug.Log($"Lab 2 - TopDownMover: {(topDownMover != null ? "✓ FOUND" : "✗ MISSING")}");

        // Lab 3: Quaternion Rotation
        Debug.Log($"Lab 3 - TurretController: {(turretController != null ? "✓ FOUND" : "✗ MISSING")}");
        if (turretController != null)
        {
            Debug.Log($"   - Target assigned: {(turretController.target != null ? "✓ YES" : "✗ NO")}");
            Debug.Log($"   - Smooth mode: {turretController.smooth}");
        }

        // Lab 4: Signed Angle
        Debug.Log($"Lab 4 - SignedAngle: {(angleScript != null ? "✓ FOUND" : "✗ MISSING")}");

        // Lab 5: Observer Pattern (C# Events)
        var healthUI = FindObjectOfType<HealthUI>();
        var healthAudio = FindObjectOfType<HealthAudio>();
        var gameOverManager = FindObjectOfType<GameOverManager>();
        Debug.Log($"Lab 5 - PlayerHealth: {(playerHealth != null ? "✓ FOUND" : "✗ MISSING")}");
        Debug.Log($"Lab 5 - HealthUI Observer: {(healthUI != null ? "✓ FOUND" : "✗ MISSING")}");
        Debug.Log($"Lab 5 - HealthAudio Observer: {(healthAudio != null ? "✓ FOUND" : "✗ MISSING")}");
        Debug.Log($"Lab 5 - GameOver Observer: {(gameOverManager != null ? "✓ FOUND" : "✗ MISSING")}");

        // Lab 6: UnityEvent version
        var unityEventHealth = FindObjectOfType<PlayerHealthUnityEvent>();
        Debug.Log($"Lab 6 - UnityEvent Health: {(unityEventHealth != null ? "✓ FOUND (Optional)" : "○ NOT USED (Using C# Events)")}");

        Debug.Log("=== CONTROLS ===");
        Debug.Log("WASD: Move player (Lab 2)");
        Debug.Log("H: Take damage (Lab 5)");
        Debug.Log("J: Heal (Lab 5)");
        Debug.Log("T: Toggle turret smooth/snap (Lab 3)");
        Debug.Log("I: Instantiate lifecycle object (Lab 1)");
        Debug.Log("D: Destroy lifecycle object (Lab 1)");
        Debug.Log("Ctrl+T: Toggle lifecycle active (Lab 1)");

        Debug.Log("=== READY TO TEST ALL LABS! ===");
    }

    private void Update()
    {
        // Additional test keys for comprehensive testing

        // Test turret target switching
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (turretController != null)
            {
                turretController.target = turretController.target == player?.transform ? null : player?.transform;
                Debug.Log("Turret target: " + (turretController.target != null ? "Player" : "None"));
            }
        }

        // Test angle script mode switching
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (angleScript != null)
            {
                angleScript.useMouse = !angleScript.useMouse;
                Debug.Log("Angle mode: " + (angleScript.useMouse ? "Mouse" : "Target"));
            }
        }
    }
}