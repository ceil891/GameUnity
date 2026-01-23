//using UnityEngine;

//public class PlayerShoot : MonoBehaviour
//{
//    public GameObject bulletPrefab;
//    public Transform firePoint;
//    public float bulletSpeed = 10f;

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
//        }
//    }

//    void Shoot()
//    {
//        Debug.Log("🔫 SHOOT CALLED!");

//        if (bulletPrefab == null || firePoint == null)
//        {
//            Debug.LogError("❌ PlayerShoot: Bullet Prefab or Fire Point not assigned!");
//            return;
//        }

//        Debug.Log($"📍 FirePoint position: {firePoint.position}");

//        GameObject bullet = Instantiate(
//            bulletPrefab,
//            firePoint.position,
//            Quaternion.identity
//        );

//        Debug.Log($"✅ Bullet instantiated at: {bullet.transform.position}");

//        // Check if bullet has SpriteRenderer
//        SpriteRenderer sr = bullet.GetComponent<SpriteRenderer>();
//        if (sr != null)
//        {
//            Debug.Log($"🎨 SpriteRenderer found. Sprite: {sr.sprite != null}, Enabled: {sr.enabled}");
//        }
//        else
//        {
//            Debug.LogError("❌ No SpriteRenderer on bullet!");
//        }

//        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
//        if (rb != null)
//        {
//            rb.linearVelocity = Vector2.up * bulletSpeed;
//            Debug.Log($"🚀 Set velocity: {rb.linearVelocity}");
//        }
//        else
//        {
//            Debug.LogError("❌ Bullet prefab missing Rigidbody2D!");
//        }

//        // Destroy bullet after 5 seconds to prevent memory leaks
//        Destroy(bullet, 5f);
//    }
//}

using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefabs;
    public float shootingInterval;
    private float lastBulletTime;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time - lastBulletTime >
            shootingInterval)
            {
                ShootBullet();
                lastBulletTime = Time.time;
            }
        }
    }

    private void ShootBullet()
    {
        Instantiate(bulletPrefabs, transform.position, transform.rotation);
    }
}