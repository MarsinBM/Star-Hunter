using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Variables
    [SerializeField] Button restart;
    [SerializeField] Button quit;

    public void OnDeath()
    {
        gameObject.SetActive(true);
        restart.onClick.AddListener(restartscene);
        quit.onClick.AddListener(Quit);
    }
    
    void restartscene()
    {
        //Debug.Log("restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Quit()
    {
        //Debug.Log("quit");
        SceneManager.LoadScene("MainMenu");
    }
}
