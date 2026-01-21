using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public bool smooth = true;

    private void Update()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;

        if (direction.sqrMagnitude < 0.0001f) return;

        // Sử dụng LookAt method (Lab yêu cầu dùng LookAt)
        if (!smooth)
        {
            // Xoay trực tiếp bằng LookAt
            transform.LookAt(target.position);
            // Trong 2D, chỉ xoay quanh trục Z
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        }
        else
        {
            // Xoay mượt bằng RotateTowards/Slerp
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                smoothSpeed * Time.deltaTime
            );
        }
    }
}