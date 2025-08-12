using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float testTimer = 0f;
    public GameObject gameManagerObject;
    public GameObject ammo;
    public GameObject gunpowder;
    public GameObject exp1;
    public GameObject exp2;
    public GameObject exp3;
    public GameObject exp4;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("gameManager");
    }

    // Update is called once per frame
    void Update()
    {
        testTimer += Time.deltaTime;

        if (testTimer >= 5f)
        {
            Destroy(gameObject);
            itemDrops(Random.Range(0, 6), Random.Range(1, 6));
            xp(Random.Range(0, 5));
            //gameManagerObject.GetComponent<gameManagerScript>().enemiesOnField -= 1;
        }

    }

    public void itemDrops(int chance, int item)
    {
        if(chance >= 4)
        {
            if(item == 1)
            {
                Instantiate(ammo, transform.position, Quaternion.identity);
            } else if (item == 2)
            {
                Instantiate(gunpowder, transform.position, Quaternion.identity);
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
}
