using UnityEngine;

public class LifecycleLogger : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log($"{name} - Awake");
    }

    private void OnEnable()
    {
        Debug.Log($"{name} - OnEnable");
    }

    private void Start()
    {
        Debug.Log($"{name} - Start");
    }

    private void Update()
    {
        Debug.Log($"{name} - Update");
    }

    private void FixedUpdate()
    {
        Debug.Log($"{name} - FixedUpdate");
    }

    private void LateUpdate()
    {
        Debug.Log($"{name} - LateUpdate");
    }

    private void OnDisable()
    {
        Debug.Log($"{name} - OnDisable");
    }

    private void OnDestroy()
    {
        Debug.Log($"{name} - OnDestroy");
    }
}