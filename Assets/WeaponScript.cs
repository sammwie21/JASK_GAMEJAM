using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private Vector3 up;
    private Vector3 left;

    public Sprite one;
    public Sprite two;

    private GameObject player;


    private SpriteRenderer s;
    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<SpriteRenderer>();
        up = new Vector3(0, 0.05f, 0);
        left = new Vector3(0.05f, 0f, 0);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerScript>().weapon == "gun")
            s.sprite = one;
        if (player.GetComponent<PlayerScript>().weapon == "sword")
            s.sprite = two;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= up;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += left;
        }

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0; 

        Vector2 direction = (mouseWorldPosition - player.transform.position).normalized;

        float radius = 1f;
        transform.position = player.transform.position + (Vector3)direction * radius;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (angle > 90 || angle < -90)
            s.flipY = true;
        else
            s.flipY = false;
    }

}
