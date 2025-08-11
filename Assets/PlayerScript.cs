using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector3 up;
    private Vector3 left;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;

    public float bulletTimer;

    public Sprite one;
    public Sprite two;

    private SpriteRenderer s;
    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<SpriteRenderer>();
        up = new Vector3(0, 0.05f, 0);
        left = new Vector3(0.05f, 0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += up;
            s.sprite = one;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= up;
            s.sprite = two;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += left;
        }

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f; 

        Vector2 aimDirection = (mouseWorldPos - firePoint.position).normalized;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot(aimDirection);
        }
    }

    void Shoot(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }
    }
}
