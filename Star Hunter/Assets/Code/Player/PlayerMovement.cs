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

    void Start()
    {
        
    }

    void Update()
    {
        movement();
    }

    void movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        Vector2 turn = new Vector2(moveX, 0.0f);

        if (turn.x == 1)
        {
            Debug.Log("pressed right");
            zRot += -Time.deltaTime * turnspeed; // NEEDS TO BE CHECKED FOR FPS
        }
        if (turn.x == -1)
        {
            Debug.Log("pressed left");
            zRot += Time.deltaTime * turnspeed;
        }

        Tplayer.rotation = Quaternion.Euler(0, 0, zRot);
    }
}
