using UnityEngine;
using UnityEngine.UI;

public class SceneSetup : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject playerPrefab;
    public GameObject turretPrefab;
    public GameObject lifecycleTestPrefab;

    [Header("UI References")]
    public Canvas canvas;
    public Text angleText;
    public Slider healthSlider;
    public Text healthText;
    public GameObject gameOverPanel;

    GameObject player;
    GameObject turret;
    GameObject lifecycleTester;

    void Start()
    {
        SetupScene();
    }

    void SetupScene()
    {
        Debug.Log("SceneSetup: Setting up scene");

        // ===== PLAYER =====
        if (playerPrefab != null)
        {
            player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            player.name = "Player";
        }

        // ===== TURRET =====
        if (turretPrefab != null)
        {
            turret = Instantiate(turretPrefab, new Vector3(3, 0, 0), Quaternion.identity);
            turret.name = "Turret";
        }

        // ===== LIFECYCLE TEST =====
        if (lifecycleTestPrefab != null)
        {
            lifecycleTester = Instantiate(lifecycleTestPrefab, new Vector3(-3, 0, 0), Quaternion.identity);
            lifecycleTester.name = "LifecycleTester";
            lifecycleTester.SetActive(false); // bật khi test
        }

        // ===== UI =====
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    // ===== STATIC PREFAB HELPERS (CHO GAMEMANAGER) =====
    public static GameObject CreatePlayerPrefab()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        go.name = "PlayerPrefab";
        return go;
    }

    public static GameObject CreateTurretPrefab()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        go.name = "TurretPrefab";
        return go;
    }

    public static GameObject CreateLifecycleTestPrefab()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.name = "LifecyclePrefab";
        go.AddComponent<LifecycleLogger>();
        return go;
    }
}
