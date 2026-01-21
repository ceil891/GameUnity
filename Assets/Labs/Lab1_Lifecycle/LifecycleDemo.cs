using UnityEngine;

public class LifecycleDemo : MonoBehaviour
{
    [Header("Prefab with LifecycleLogger")]
    public GameObject prefabWithLifecycleLogger;

    [HideInInspector]
    public GameObject _instantiatedObject;

    void Update()
    {
        // Nhấn I để Instantiate
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (_instantiatedObject == null && prefabWithLifecycleLogger != null)
            {
                _instantiatedObject = Instantiate(prefabWithLifecycleLogger);
                _instantiatedObject.name = "LifecycleTestObject";
                Debug.Log("Instantiated Lifecycle Test Object");
            }
        }

        // Nhấn D để Destroy
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (_instantiatedObject != null)
            {
                Destroy(_instantiatedObject);
                _instantiatedObject = null;
                Debug.Log("Destroyed Lifecycle Test Object");
            }
        }
    }
}
