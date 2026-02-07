using UnityEngine;

public class SimplePlayerShooting : MonoBehaviour
{
    public static SimplePlayerShooting instance;

    public int weaponPower = 1;
    public int maxweaponPower = 4;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.2f;

    float lastFire;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time > lastFire)
            {
                Shoot();
                lastFire = Time.time + fireRate;
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
}
