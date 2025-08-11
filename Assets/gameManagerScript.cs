using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject portal;
    public int enemyLimit;
    public int enemiesOnField;
    public float spawnTimer;
    public float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0f;
        spawnRate = 7f;
        enemiesOnField = 0;
        enemyLimit = Random.Range(7,12);
        for (int i = 0; i <= 4; i++)
        {
            portalMaking(Random.Range(-9, 10), Random.Range(-5, 6));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate)
        {
                enemyLimit = Random.Range(7, 12);
                for (int i = 0; i <= enemyLimit; i++)
                {
                    enemySpawning(Random.Range(-5, 6), Random.Range(-3, 4));
                }
            spawnTimer = 0f;
        }
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            
            for (int i = 0; i <= 4; i++)
            {
                portalMaking(Random.Range(-9, 10), Random.Range(-5, 6));
            }
        }*/


    }

    public void enemySpawning(int x, int y)
    {
        Instantiate(enemy, new Vector3(x, y, 0), Quaternion.identity);
        enemiesOnField += 1;
    }

    public void portalMaking(int x, int y)
    {
          Instantiate(portal, new Vector3(x, y, 0), Quaternion.identity);
    }
}
