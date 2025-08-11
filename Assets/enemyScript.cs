using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float testTimer = 0f;
    public GameObject gameManagerObject;
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
            //gameManagerObject.GetComponent<gameManagerScript>().enemiesOnField -= 1;
        }

    }
}
