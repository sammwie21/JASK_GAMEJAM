using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public float swingDuration = 0.2f;
    public float swingAngle = 150f;

    private bool swinging = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private float swingTime;


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



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<enemyScript>().health -= 2;
        }
    }
}


