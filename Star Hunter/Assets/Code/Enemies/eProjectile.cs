using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eProjectile : MonoBehaviour
{
    // Variables 
    [SerializeField] float speed;
    private float TimetoDestroy = 2;

    [SerializeField] Transform ebullet;

    
    void Start()
    {
        death();
    }

    
    void Update()
    {
        Move();
    }

    // Projectile gets destroyed after 'x' amount of time
    void death()
    {
        Destroy(gameObject, TimetoDestroy);
    }

    // Projectile Movement
    void Move()
    {
        GameObject player = GameObject.Find("Player");
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    // Collision detection
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("ebullet"))
        {
            Physics2D.IgnoreCollision(ebullet.GetComponent<Collider2D>(), ebullet.GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(ebullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
