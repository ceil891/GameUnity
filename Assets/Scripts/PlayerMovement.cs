using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // A D
        float v = Input.GetAxis("Vertical");   // W S

        Vector3 move = new Vector3(h, v, 0);
        transform.Translate(move * speed * Time.deltaTime);
    }
}
