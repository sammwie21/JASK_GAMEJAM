using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class gameManagerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject child;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject portal1;
    public GameObject portal2;
    public GameObject portal3;
    public int enemyLimit;
    public int enemiesOnField;
    public float spawnTimer;
    public float spawnRate;
    public float gameTimer = 60f;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI Ammo;
    public TextMeshProUGUI exp;
    public TextMeshProUGUI Health;
    public int area = 0;
    private List<Transform> portalPositions = new List<Transform>();
    public bool bossSpawned;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0f;
        spawnRate = 4.5f;
        enemiesOnField = 0;
        enemyLimit = 10;
        for (int i = 0; i <= 2; i++)
        {
            portalMaking();
        }
        childSpawning(Random.Range(0, 3));
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;
        Timer.text = gameTimer.ToString("0.00") + " seconds left.";
        Ammo.text = player.GetComponent<PlayerScript>().ammo + "/" + player.GetComponent<PlayerScript>().maxAmmo;
        exp.text = player.GetComponent<PlayerScript>().xp + " xp points";
        Health.text = "HP: " + player.GetComponent<PlayerScript>().health;

        if (gameTimer >= 0)
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnRate)
            {
                for (int i = 0; i < enemyLimit; i++)
                {
                    enemySpawning();
                }
                spawnTimer = 0f;
            }
        } else if (gameTimer < 0 || player.GetComponent<PlayerScript>().health == 0)
        {
            gameTimer = 0;
            Debug.Log("Game over, you lose");
        }

    }

    public void enemySpawning()
    {
        if (portalPositions.Count == 0) return;
        if (player.GetComponent<Transform>().position.y <= 19f && player.GetComponent<Transform>().position.y >= -19f)
        {
            Transform portalPos = portalPositions[Random.Range(0, portalPositions.Count)];
            Instantiate(enemy1, portalPos.position, Quaternion.identity);
            enemiesOnField += 1;
            bossSpawned = false;
        } else if (player.GetComponent<Transform>().position.y < 73f && player.GetComponent<Transform>().position.y > 48f)
        {
            Instantiate(enemy2, new Vector3(Random.Range(-100, -21), Random.Range(40, 56), 0), Quaternion.identity);
            enemiesOnField += 1;
            if (bossSpawned == false)
            {
                Instantiate(enemy3, new Vector3(Random.Range(-100, -21), Random.Range(40, 56), 0), Quaternion.identity);
                bossSpawned = true;
                enemiesOnField += 1;
            }
        }
        else if (player.GetComponent<Transform>().position.y < -86f && player.GetComponent<Transform>().position.y > -107f)
        {
            Instantiate(enemy2, new Vector3(Random.Range(30, 121), Random.Range(-80, -96), 0), Quaternion.identity);
            enemiesOnField += 1;
            if (bossSpawned == false)
            {
                Instantiate(enemy3, new Vector3(Random.Range(30, 121), Random.Range(-80, -96), 0), Quaternion.identity);
                bossSpawned = true;
                enemiesOnField += 1;
            }
        }
        else if (player.GetComponent<Transform>().position.y <-65f && player.GetComponent<Transform>().position.y > -85f)
        {
            Instantiate(enemy2, new Vector3(Random.Range(-130, -44), Random.Range(-60, -76), 0), Quaternion.identity);
            enemiesOnField += 1;
            if (bossSpawned == false)
            {
                Instantiate(enemy3, new Vector3(Random.Range(-130, -44), Random.Range(-60, -76), 0), Quaternion.identity);
                bossSpawned = true;
                enemiesOnField += 1;
            }
        }
    }


    public void portalMaking()
    {
        GameObject p = null;

        if (area == 0)
        {
            p = Instantiate(portal1, new Vector3(Random.Range(20, 44), Random.Range(-1, -4), 0), Quaternion.identity);
        }
        else if (area == 1)
        {
            p = Instantiate(portal2, new Vector3(Random.Range(-44, -20), Random.Range(-1, -4), 0), Quaternion.identity);
        }
        else if (area == 2)
        {
            p = Instantiate(portal3, new Vector3(Random.Range(-43, 44), Random.Range(-9, -14), 0), Quaternion.identity);
        }

        if (p != null)
        {
            portalPositions.Add(p.transform);
            area += 1;
        }
    }

    public void childSpawning(int childSpawn)
    {
        if (childSpawn == 0)
        {
            Instantiate(child, new Vector3(Random.Range(-123, -37), Random.Range(52, 67), 0), Quaternion.identity);
            
            Debug.Log("Portal 1");
        }
        else if (childSpawn == 1)
        {
            Instantiate(child, new Vector3(Random.Range(56, 145), Random.Range(-93, -108), 0), Quaternion.identity);
            
            Debug.Log("Portal 2");
        }
        else if (childSpawn == 2)
        {
            Instantiate(child, new Vector3(Random.Range(-164, -77), Random.Range(-72, -87), 0), Quaternion.identity);
            Debug.Log("Portal 3");
        }
    }

}
