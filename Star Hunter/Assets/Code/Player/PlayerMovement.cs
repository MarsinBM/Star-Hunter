using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    [SerializeField] float turnspeed;
    [SerializeField] float accelspeed;
    [SerializeField] float maxspeed;

    [SerializeField] Transform Tplayer;
    [SerializeField] Rigidbody2D Rplayer;

    void Start()
    {
        //Application.targetFrameRate = 15;
    }

    void Update()
    {
        movement();  
    }
    void FixedUpdate()
    {
        freezeship();
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

}
