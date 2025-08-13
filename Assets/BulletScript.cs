using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float timer;
    private GameObject player;
    private GameObject pet;
    // Start is called before the first frame update
    void Start()
    {
        pet = GameObject.FindGameObjectWithTag("Pet");
        player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.gameObject.GetComponent<PolygonCollider2D>(), gameObject.GetComponent<PolygonCollider2D>(), true);
        Physics2D.IgnoreCollision(pet.gameObject.GetComponent<PolygonCollider2D>(), gameObject.GetComponent<PolygonCollider2D>(), true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 3f)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
