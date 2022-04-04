using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    // Variables
    [SerializeField] float speed;
    [SerializeField] float maxspeed;

    [SerializeField] Rigidbody2D enemy;
    [SerializeField] Rigidbody2D player;

    public bool idle;
    float TTI = 10;
    private bool leftvision;

    public int health = 2;

    void Start()
    {
        idle = true;
    }

    
    void Update()
    {
        Idle();
        chase();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Handles how the enemy acts when it's idle
    void Idle()
    {
        if (idle == true)
        {
            enemy.velocity = Vector2.Lerp(enemy.velocity, Vector2.zero, Time.deltaTime * 1);
        }
    }

    // Controls the enemy chase movement
    void chase()
    {
        if (idle != true)
        {
            enemy.AddForce((player.position - enemy.position) * Time.deltaTime * speed);

            if (enemy.velocity.magnitude > maxspeed)
            {
                enemy.velocity = enemy.velocity.normalized * maxspeed;
            }
        }
        
        if (leftvision == true)
        {
            TTI -= Time.deltaTime;
            if (TTI <= 0)
            {
                idle = true;
                TTI = 10;
            }
        }

    }

    // Handles the collision detection
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), enemy.GetComponent<Collider2D>());
        }
        else if (collision.gameObject.name == "Player")
        {
            idle = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), enemy.GetComponent<Collider2D>());
        }
        else if (idle == false)
        {
            leftvision = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pbullet") && idle != true)
        {
            health -= 1;
        }
    }
}
