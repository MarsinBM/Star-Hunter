using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alarm : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject enemy;

    // 'Activates' enemy if the player enters the trigger 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            enemy2 escript = enemy.GetComponent<enemy2>();
            escript.idle = false;
            Destroy(gameObject);
        }
    }
}
