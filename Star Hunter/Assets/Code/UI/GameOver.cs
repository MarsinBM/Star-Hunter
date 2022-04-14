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

    [SerializeField] AudioSource click;

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
        Player.score = Player.totalscore;
        click.Play();
    }

    void Quit()
    {
        //Debug.Log("quit");
        SceneManager.LoadScene("MainMenu");
        Player.score = 0;
        click.Play();
    }
}
