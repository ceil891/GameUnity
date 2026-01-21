using UnityEngine;
using UnityEngine.UI;

public class TopdownSignedAngle : MonoBehaviour
{
    public bool useMouse = true;

    public Transform target;
    public Text angleText;

    void Update()
    {
        Vector3 dir;

        if (useMouse)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.transform.position.y;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            dir = worldPos - transform.position;
        }
        else if (target != null)
        {
            dir = target.position - transform.position;
        }
        else return;

        float angle = Vector2.SignedAngle(Vector2.up, new Vector2(dir.x, dir.z));
        transform.rotation = Quaternion.Euler(0, angle, 0);

        if (angleText != null)
            angleText.text = $"Angle: {angle:F1}";
    }
}
