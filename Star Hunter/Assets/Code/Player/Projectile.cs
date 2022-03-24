using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Variables
    private float TimetoDestory = 4.5f;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D projectile;
    [SerializeField] GameObject player;

    void Start()
    {
        death();   
    }

    void Update()
    {
        move();
    }

    // Projectile gets destroyed after 'x' amount of time
    void death()
    {
        Destroy(gameObject, TimetoDestory);
    }

    // Projectile movement
    void move()
    {
        projectile.AddRelativeForce(Vector2.up * Time.deltaTime * speed);
    }

    // Projectile gets destroyed on collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pbullet"))
        {
            Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), projectile.GetComponent<Collider2D>());
        }
        else
        Destroy(gameObject);
    }
}
