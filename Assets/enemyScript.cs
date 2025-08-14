using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float runTimer = 0f;
    public float despawnTime;
    private GameObject target;
    public float speed = 4f;
    public int health;
    public int enemyDmg;
    public GameObject gameManagerObject;
    public GameObject ammo;
    public GameObject extarTime;
    public GameObject healthPack;
    public GameObject exp1;
    public GameObject exp2;
    public GameObject exp3;
    public GameObject exp4;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("gameManager");
        target = GameObject.FindGameObjectWithTag("Player"); 
        //health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        runTimer += Time.deltaTime;

        if(health < 1)
        {
            Destroy(gameObject);
            itemDrops(Random.Range(0, 8), Random.Range(1, 4));
            xp(Random.Range(0, 5));
        } else if (runTimer >= despawnTime)
        {
            Destroy(gameObject);
            runTimer = 0;
        }

    }

    public void itemDrops(int chance, int item)
    {
        if(chance >= 5)
        {
            if(item == 1)
            {
                Instantiate(ammo, transform.position, Quaternion.identity);
            } else if (item == 2)
            {
                Instantiate(extarTime, transform.position, Quaternion.identity);
            }
            else if (item == 3)
            {
                Instantiate(healthPack, transform.position, Quaternion.identity);
            }
        }
    }

    public void xp(int xp)
    {
        if (xp == 1)
        {
            Instantiate(exp1, transform.position, Quaternion.identity);
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

        if(collision.gameObject.tag == "Player")
        {
            target.GetComponent<PlayerScript>().health -= enemyDmg;
        }
    }
}
