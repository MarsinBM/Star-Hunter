using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Variables
    private bool GameEnded = false;
    public GameOver GameOver;

    [SerializeField] AudioSource die;

    public void calldeath()
    {
        if (GameEnded == false)
        {
            die.Play();
            Debug.Log("death sequence");
            GameOver.OnDeath();
            GameEnded = true;
        } 
    }
}
