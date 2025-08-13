using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class gameManagerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject portal;
    public int enemyLimit;
    public int enemiesOnField;
    public float spawnTimer;
    public float spawnRate;
    public float gameTimer = 45f;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI Ammo;
    public TextMeshProUGUI exp;
    public int area = 0;
    private List<Transform> portalPositions = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0f;
        spawnRate = 3f;
        enemiesOnField = 0;
        enemyLimit = Random.Range(7,12);
        for (int i = 0; i <= 2; i++)
        {
            portalMaking();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;
        Timer.text = gameTimer.ToString("0.00") + " seconds left.";
        Ammo.text = player.GetComponent<PlayerScript>().ammo + "/" + player.GetComponent<PlayerScript>().maxAmmo;
        exp.text = player.GetComponent<PlayerScript>().xp + " xp points";
        if (gameTimer >= 0)
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnRate)
            {
                enemyLimit = Random.Range(7, 12);
                for (int i = 0; i < enemyLimit; i++)
                {
                    enemySpawning();
                }
                spawnTimer = 0f;
            }
        } else if (gameTimer < 0)
        {
            gameTimer = 0;
            Debug.Log("Game over, you lose");
        }

    }

    public void enemySpawning()
    {
        if (portalPositions.Count == 0) return;

        Transform portalPos = portalPositions[Random.Range(0, portalPositions.Count)];
        Instantiate(enemy, portalPos.position, Quaternion.identity);
        enemiesOnField += 1;
    }


    public void portalMaking()
    {
        GameObject p = null;

        if (area == 0)
        {
            p = Instantiate(portal, new Vector3(Random.Range(20, 44), Random.Range(-1, -5), 0), Quaternion.identity);
        }
        else if (area == 1)
        {
            p = Instantiate(portal, new Vector3(Random.Range(-44, -20), Random.Range(-1, -5), 0), Quaternion.identity);
        }
        else if (area == 2)
        {
            p = Instantiate(portal, new Vector3(Random.Range(-43, 44), Random.Range(-9, -4), 0), Quaternion.identity);
        }

        if (p != null)
        {
            portalPositions.Add(p.transform);
            area += 1;
        }
    }

}
