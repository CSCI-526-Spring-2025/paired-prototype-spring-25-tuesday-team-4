using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public Transform firePoint; // Bullet spawn point
    public GameObject bulletPrefab; // Bullet prefab
    public Transform player; // Reference to player

    public List<ColorType> bulletColors = new List<ColorType> { ColorType.Red, ColorType.Blue, ColorType.Yellow }; // Preset bullet colors
    // public List<ColorType> bulletColors = new List<ColorType> { ColorType.Red, ColorType.Yellow }; // Preset bullet colors


    private int currentColorIndex = 0;

    private BulletManager bulletManager;

    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    public ColorType getCurrentColor() {
        return bulletColors[currentColorIndex];
    }

    void Update()
    {
        // Rotate gun to face mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Flip gun if mouse is on the left
        if (mousePosition.x < player.position.x)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        // Shoot bullet when left mouse button is pressed
        if (Input.GetMouseButtonDown(0) && bulletManager.GetBulletCount() > 0)
        {
            Shoot();
            bulletManager.FireBullet();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeBulletColor();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        if (bulletScript != null)
        {
            bulletScript.SetBulletColor(bulletColors[currentColorIndex]); // Set bullet color
        }
    }

    void ChangeBulletColor()
    {
        currentColorIndex = (currentColorIndex + 1) % bulletColors.Count; // Cycle through colors
        Debug.Log("Bullet Color Changed: " + bulletColors[currentColorIndex]);
    }
}
