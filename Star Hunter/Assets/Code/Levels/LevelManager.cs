using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Variables
    private bool GameEnded = false;
    public GameOver GameOver;

    public void calldeath()
    {
        if (GameEnded == false)
        {
            Debug.Log("death sequence");
            GameOver.OnDeath();
            GameEnded = true;
        }
        
    }
}
