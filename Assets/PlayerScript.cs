using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector3 up;
    private Vector3 left;

    public GameObject bulletPrefab;
    private GameObject ws;
    private Transform firePoint;
    public float bulletSpeed = 5f;

    public float bulletTimer;

    public Sprite one;
    public Sprite two;


    private SpriteRenderer s;

    public int ammo;

    public int xp = 0;

    public int level;

    public string weapon;
    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<SpriteRenderer>();
        up = new Vector3(0, 0.05f, 0);
        left = new Vector3(0.05f, 0f, 0);
        ammo = 15;
        level = 1;
        weapon = "gun";
        ws = GameObject.Find("Weapon");
        firePoint = ws.transform;
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

        if (Input.GetMouseButtonDown(0) && ammo > 0 && weapon == "gun")
        {
            Shoot(aimDirection);
            ammo--;
        }

        if(level == 1 && xp == 15)
        {
            ammo = 25;
            level = 2;
            xp = 0;
        }

        if (level == 2 && xp == 30)
        {
            ammo = 30;
            level = 3;
            xp = 0;
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            weapon = "gun";
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            weapon = "sword";
        }
    }

    void Shoot(Vector2 direction)
    { 
        firePoint.position = ws.transform.position;
        GameObject bullet = Instantiate(bulletPrefab, ws.transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Powerup" && level == 1)
        {
            ammo = 15;
        }

        if (collision.gameObject.tag == "Powerup" && level == 2)
        {
            ammo = 25;
        }

        if (collision.gameObject.tag == "Powerup" && level == 3)
        {
            ammo = 30;
        }

        if (collision.gameObject.tag == "XP")
        {
            xp++;
        }
    }
}
