using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        transform.position = Vector3.MoveTowards(
            transform.position,
            mousePos,
            speed * Time.deltaTime
        );
    }
}
