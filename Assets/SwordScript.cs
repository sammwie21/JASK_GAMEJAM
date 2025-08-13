using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public float swingDuration = 0.2f;
    public float swingAngle = 90f;

    private bool swinging = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private float swingTime;

    private List<GameObject> hitEnemies = new List<GameObject>();

    void Update()
    {
        if (swinging)
        {
            swingTime += Time.deltaTime;
            float percent = swingTime / swingDuration;

            transform.localRotation = Quaternion.Slerp(initialRotation, targetRotation, percent);

            if (percent >= 1f)
            {
                swinging = false;
                hitEnemies.Clear(); // Allow to hit again next time
                transform.localRotation = initialRotation;
            }
        }
    }

    public void Swing()
    {
        if (!swinging)
        {
            swinging = true;
            swingTime = 0f;
            initialRotation = transform.localRotation;
            targetRotation = initialRotation * Quaternion.Euler(0, 0, swingAngle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (swinging && collision.gameObject.tag == "Enemy" && !hitEnemies.Contains(collision.gameObject))
        {
            enemyScript enemy = collision.GetComponent<enemyScript>();
            if (enemy != null)
            {
                enemy.GetComponent<enemyScript>().health -= 2;
                hitEnemies.Add(collision.gameObject);
            }
        }
        */

        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hi");
            Destroy(collision.gameObject);
        }
    }
}
