using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie1Script : MonoBehaviour
{
    private GameObject target;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
}
