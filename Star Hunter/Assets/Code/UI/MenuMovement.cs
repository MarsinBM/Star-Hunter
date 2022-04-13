using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMovement : MonoBehaviour
{
    // Variables
    [SerializeField] float aspeed;
    [SerializeField] float mspeed;
    [SerializeField] Rigidbody2D player;

    void Update()
    {
        player.AddRelativeForce(Vector2.up * Time.deltaTime * aspeed);

        if (player.velocity.magnitude > mspeed)
        {
            player.velocity = player.velocity.normalized * mspeed;
        }
    }
}
