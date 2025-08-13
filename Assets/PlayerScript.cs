using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector3 up;
    private Vector3 left;

    public GameObject gameManagerObject;
    public GameObject bulletPrefab;
    private GameObject ws;
    private Transform firePoint;
    public float bulletSpeed = 5f;

    public float bulletTimer;

    public Sprite one;
    public Sprite two;


    private SpriteRenderer s;

    public int ammo;
    public int maxAmmo;

    public int xp = 0;

    public int level;

    public string weapon;

    public int health;
    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<SpriteRenderer>();
        up = new Vector3(0, 0.05f, 0);
        left = new Vector3(0.05f, 0f, 0);
        ammo = 15;
        maxAmmo = 45;
        level = 1;
        weapon = "gun";
        ws = GameObject.Find("Weapon");
        firePoint = ws.transform;
        health = 10000000;
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
        if(ammo == 0 && maxAmmo > 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (level == 1)
                {
                    maxAmmo -= 15;
                    ammo += 15;
                }
                else if (level == 2)
                {
                    maxAmmo -= 25;
                    ammo += 25;
                }
                else if (level == 3)
                {
                    maxAmmo -= 30;
                    ammo += 30;
                }
            }
        }
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f; 

        Vector2 aimDirection = (mouseWorldPos - firePoint.position).normalized;

        if (Input.GetMouseButtonDown(0) && ammo > 0 && weapon == "gun")
        {
            Shoot(aimDirection);
            ammo--;

        }

        if (Input.GetMouseButtonDown(0) && weapon == "sword")
        {
            ws.GetComponent<SwordScript>().Swing();
        }

        if (level == 1 && xp == 15)
        {
            maxAmmo = 75;
            ammo = 25;
            level = 2;
            xp = 0;
        }

        if (level == 2 && xp == 30)
        {
            maxAmmo = 90;
            ammo = 30;
            level = 3;
            xp = 0;
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            weapon = "gun";
            ws.GetComponent<PolygonCollider2D>().enabled = false;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            weapon = "sword";
            ws.GetComponent<PolygonCollider2D>().enabled = true;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            //END SCREEN
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
            maxAmmo = 45;
        }

        if (collision.gameObject.tag == "Powerup" && level == 2)
        {
            ammo = 25;
            maxAmmo = 75;
        }

        if (collision.gameObject.tag == "Powerup" && level == 3)
        {
            ammo = 30;
            maxAmmo = 90;
        }

        if (collision.gameObject.tag == "XP")
        {
            xp++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "ammo")
        {
            maxAmmo += maxAmmo / 3;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Time")
        {
            gameManagerObject.GetComponent<gameManagerScript>().gameTimer += 15f;
            Destroy(collision.gameObject);
        }
    }
}
