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

    private bool idle;
    private bool attacking;
    
    void Start()
    {
        idle = false;
        attacking = false;
    }

    
    void Update()
    {
        attack();
        chase();
        Idle();
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
        if (distance < attackdistance)
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
        }
        
    }
}
