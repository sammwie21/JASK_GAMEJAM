using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetScript : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 offset = new Vector3(1, 0, 0);
    public float DetectionRadius = 7f;

    private GameObject target;
    private GameObject currentEnemy;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (currentEnemy != null)
        {
            if (Vector3.Distance(transform.position, currentEnemy.transform.position) > DetectionRadius || currentEnemy == null)
            {
                currentEnemy = null;
            }
        }

        if (currentEnemy == null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            float closestDist = Mathf.Infinity;
            GameObject closestEnemy = null;

            foreach (GameObject e in enemies)
            {
                float dist = Vector3.Distance(transform.position, e.transform.position);
                if (dist < closestDist && dist <= DetectionRadius)
                {
                    closestDist = dist;
                    closestEnemy = e;
                }
            }

            if (closestEnemy != null)
            {
                currentEnemy = closestEnemy;
            }
        }

        if (currentEnemy != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentEnemy.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position + offset, speed * Time.deltaTime);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}