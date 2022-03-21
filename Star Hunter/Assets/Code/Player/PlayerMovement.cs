using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    [SerializeField] float turnspeed;
    [SerializeField] float speed;
    [SerializeField] Transform Tplayer;
    private float zRot;
    private float xPush;

    void Start()
    {
        //Application.targetFrameRate = 15;
    }

    void Update()
    {
        movement();
    }

    // Controls player movement
    void movement()
    {
        // Movement Variables
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 turn = new Vector2(moveX, 0.0f);
        Vector2 push = new Vector2(0.0f, moveY);

        // Changes player rotation
        if (turn.x == 1)
        {
            //Debug.Log("pressed right");
            zRot += -Time.deltaTime * turnspeed; 
        }
        if (turn.x == -1)
        {
            //Debug.Log("pressed left");
            zRot += Time.deltaTime * turnspeed;
        }

        Tplayer.rotation = Quaternion.Euler(0, 0, zRot);

        // Moves player forward and backwards
        if (push.y == 1)
        {
            Debug.Log("pressed up");
            Tplayer.position += Vector3.forward * Time.deltaTime * speed;
        }

        if (push.y == -1)
        {
            Debug.Log("pressed down");
            Tplayer.position -= Vector3.forward * Time.deltaTime * speed;
        }
    }
}
