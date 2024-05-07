using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform foot;
    public float speed = 5, jumpStrenght = 5, bulletSpeed = 8;
    float horizontal;
    public Rigidbody2D body;
    bool groundCheck;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);

        groundCheck = Physics2D.OverlapCircle(foot.position, 0.05f);

        if (Input.GetButtonDown("Jump") && groundCheck)
        {
            body.AddForce(new Vector2(0, jumpStrenght + 100));
        }

        if (Input.GetButtonDown("Fire1"))
        {

            GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);//destroi enimigo
            Destroy(gameObject);//destroi o tiro

        }
    }
}