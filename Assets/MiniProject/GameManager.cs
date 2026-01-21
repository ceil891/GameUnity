using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        // Tự động setup scene khi game bắt đầu
        if (FindObjectOfType<SceneSetup>() == null)
        {
            GameObject setupGO = new GameObject("SceneSetup");
            SceneSetup setup = setupGO.AddComponent<SceneSetup>();

            // Tạo prefabs cơ bản nếu chưa có
            setup.playerPrefab = SceneSetup.CreatePlayerPrefab();
            setup.turretPrefab = SceneSetup.CreateTurretPrefab();
            setup.lifecycleTestPrefab = SceneSetup.CreateLifecycleTestPrefab();

            Debug.Log("Auto-created SceneSetup with basic prefabs");
        }
    }

    void Update()
    {
        // Controls cho lifecycle demo
        if (Input.GetKeyDown(KeyCode.I))
        {
            LifecycleDemo demo = FindObjectOfType<LifecycleDemo>();
            if (demo == null)
            {
                GameObject demoGO = new GameObject("LifecycleDemo");
                demo = demoGO.AddComponent<LifecycleDemo>();
                demo.prefabWithLifecycleLogger = SceneSetup.CreateLifecycleTestPrefab();
            }
            // Trigger instantiate (thực hiện trong LifecycleDemo.Update())
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.T)))
        {
            LifecycleDemo demo = FindObjectOfType<LifecycleDemo>();
            if (demo != null && demo.GetComponent<LifecycleDemo>()._instantiatedObject != null)
            {
                demo.GetComponent<LifecycleDemo>()._instantiatedObject.SetActive(
                    !demo.GetComponent<LifecycleDemo>()._instantiatedObject.activeSelf);
                Debug.Log("Toggled lifecycle object active: " +
                         demo.GetComponent<LifecycleDemo>()._instantiatedObject.activeSelf);
            }
        }
    }
}