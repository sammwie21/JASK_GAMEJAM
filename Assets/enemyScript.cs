using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float testTimer = 0f;
    private GameObject target;
    public float speed = 2f;
    public int health;
    public GameObject gameManagerObject;
    public GameObject ammo;
    public GameObject extarTime;
    public GameObject exp1;
    public GameObject exp2;
    public GameObject exp3;
    public GameObject exp4;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("gameManager");
        target = GameObject.FindGameObjectWithTag("Player");
        health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        testTimer += Time.deltaTime;

        if(health < 1)
        {
            Destroy(gameObject);
            itemDrops(Random.Range(0, 6), Random.Range(1, 3));
            xp(Random.Range(0, 5));
        }

    }

    public void itemDrops(int chance, int item)
    {
        if(chance >= 3)
        {
            if(item == 1)
            {
                Instantiate(ammo, transform.position, Quaternion.identity);
            } else if (item == 2)
            {
                Instantiate(extarTime, transform.position, Quaternion.identity);
            }
        }
    }

    public void xp(int xp)
    {
        if (xp == 1)
        {
            Instantiate(exp1, transform.position, Quaternion.identity);
        } 
        else if (xp == 2)
        {
            Instantiate(exp2, transform.position, Quaternion.identity);
        }
        else if (xp == 3)
        {
            Instantiate(exp3, transform.position, Quaternion.identity);
        }
        else if (xp == 4)
        {
            Instantiate(exp4, transform.position, Quaternion.identity);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            if (target.GetComponent<PlayerScript>().level == 1)
            {
                health -= 1;
            }
            if (target.GetComponent<PlayerScript>().level == 2)
            {
                health -= 2;
            }
            if (target.GetComponent<PlayerScript>().level == 3)
            {
                health -= 3;
            }
            Destroy(collision.gameObject);
        }
    }
}
