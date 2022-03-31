using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    // Variables
    [SerializeField] float speed;
    [SerializeField] float orbitspeed;
    [SerializeField] float distbplayer;

    [SerializeField] float attackdistance;

    [SerializeField] Transform enemy;
    [SerializeField] Transform player;

    [SerializeField] GameObject ebullet;
    private float cooldown = 1;

    Quaternion rotation;

    public int health = 5;

    public bool idle;
    private bool attacking;
    
    void Start()
    {
        idle = true;
        attacking = false;
        rotation = transform.rotation;
    }

    
    void Update()
    {
        attack();
        chase();
        Idle();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void LateUpdate()
    {
        transform.rotation = rotation;
    }

    // Handles how the enemy acts when it's idle
    void Idle()
    {

    }

    // Handles moving towards to the player when they spot them
    void chase()
    {
        if (idle != true && attacking != true)
        {
            enemy.position = Vector2.MoveTowards(enemy.position, player.position, speed * Time.deltaTime);
        }

        float distance = Vector2.Distance(enemy.position, player.position);
        if (distance < attackdistance && idle != true)
        {
            attacking = true;
        }
    }

    // Makes enemy rotate around player 
    void attack()
    {
        Vector3 zAxis = new Vector3(0,0,1);
        
        if (attacking == true)
        {
            enemy.RotateAround(player.position, zAxis, orbitspeed * Time.deltaTime);
            enemy.position = (enemy.position - player.position).normalized * distbplayer + player.position;
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                Instantiate(ebullet, enemy.position, enemy.rotation);
                cooldown = 1;
            }
        } 
    }

    // Handles the collision detection
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pbullet"))
        {
            health -= 1;
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), enemy.GetComponent<Collider2D>());
        }
    }
}
