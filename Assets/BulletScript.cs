using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float timer;
    private GameObject child;
    private GameObject player;
    private GameObject pet;
    private SpriteRenderer s;
    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<SpriteRenderer>();
        pet = GameObject.FindGameObjectWithTag("Pet");
        player = GameObject.FindGameObjectWithTag("Player");
        child = GameObject.FindGameObjectWithTag("Daughter");
        Physics2D.IgnoreCollision(player.gameObject.GetComponent<PolygonCollider2D>(), gameObject.GetComponent<PolygonCollider2D>(), true);
        Physics2D.IgnoreCollision(pet.gameObject.GetComponent<PolygonCollider2D>(), gameObject.GetComponent<PolygonCollider2D>(), true);
        Physics2D.IgnoreCollision(child.gameObject.GetComponent<PolygonCollider2D>(), gameObject.GetComponent<PolygonCollider2D>(), true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 3f)
        {
            Destroy(gameObject);
        }

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        Vector2 direction = (mouseWorldPosition - player.transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        
        if (angle > 90 || angle < -90)
            s.flipY = true;
        else
            s.flipY = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject); 
        }

        if (collision.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }
    }
}
