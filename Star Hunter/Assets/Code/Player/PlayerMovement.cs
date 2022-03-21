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
    private float yPush;

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
        Vector2 turn = new Vector2(moveX, 0.0f);

        // Moves player forward and backwards
        yPush = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        transform.Translate(0.0f, yPush, 0.0f);

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

        
    }
}
