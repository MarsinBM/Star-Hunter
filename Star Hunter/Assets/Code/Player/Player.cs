using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Variables
    [SerializeField] float turnspeed;
    [SerializeField] float accelspeed;
    [SerializeField] float maxspeed;

    [SerializeField] Transform Tplayer;
    [SerializeField] Rigidbody2D Rplayer;

    [SerializeField] Transform firepoint;
    [SerializeField] GameObject projectile;

    private bool dead = false;

    private bool Isfiring;
    private float cooldown = 0.25f;

    public int health = 5;

    public static int score = 0;
    public static int totalscore;

    public SpriteRenderer players;

    void Start()
    {
        // FOR TESTING AT LOW FRAMERATES
        //Application.targetFrameRate = 15;
        totalscore = score;
    }

    void Update()
    {
        if (dead != true)
        {
            movement();
            shoot();
        }
        
        if (health <= 0)
        {
            //Destroy(gameObject);
            colorchange();
            FindObjectOfType<LevelManager>().calldeath();
            dead = true;
        }
    }
    void FixedUpdate()
    {
        if (dead != true)
        {
            freezeship();
        }
        
    }

    // Controls player movement
    void movement()
    {
        // Movement Variables
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 turn = new Vector2(moveX, 0.0f);
        Vector2 push = new Vector2(0.0f, moveY);

        // Moves player forward and backwards
        if (push.y == 1)
        {
            Rplayer.AddRelativeForce(Vector2.up * Time.deltaTime * accelspeed);
        }

        if (push.y == -1)
        {
            Rplayer.AddRelativeForce(Vector2.up * Time.deltaTime * -accelspeed);
        }

        if (Rplayer.velocity.magnitude > maxspeed)
        {
            Rplayer.velocity = Rplayer.velocity.normalized * maxspeed;
        }

        // Changes player rotation
        if (turn.x == 1)
        {
            Rplayer.angularVelocity = -turnspeed;
        }
        if (turn.x == -1)
        {
           
            Rplayer.angularVelocity = turnspeed;
        }
        if (turn.x == 0)
        {
            Rplayer.angularVelocity = 0;
        }
    }

    // Controls the stopping of the ship
    void freezeship()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Rplayer.velocity = Vector2.Lerp(Rplayer.velocity, Vector2.zero, Time.deltaTime * 1);
        }
    }

    // Allows player to shoot projectile
    void shoot()
    {
        if (Input.GetKey(KeyCode.Z) && Isfiring == false)
        {
            Instantiate(projectile, firepoint.position, Tplayer.rotation);
            Isfiring = true;
        }

        if (Isfiring == true && cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            if(cooldown <= 0)
            {
                Isfiring = false;
                cooldown = 0.25f;
            }
        }
    }

    // Changes players color depending on health
    void colorchange()
    {  
        players.color = new Color32(75, 75, 75, 255);
    }

    // Players collision detection for health
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("ebullet"))
        {
            health -= 1;
        }
    }

    // Players collision detection for score
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("score"))
        {
            score += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("health"))
        {
            health = 5;
            Destroy(other.gameObject);
        }
    }

}
