using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Variables
    [SerializeField] Image star;
    private float zRot;
    
    [SerializeField] Text maintext;
    private float textsizeF = 80;
    private bool big = false;

    [SerializeField] Button play;
    [SerializeField] Button controls;
    [SerializeField] Button quit;

    void Start()
    {
        play.onClick.AddListener(Play);
        controls.onClick.AddListener(Controls);
        quit.onClick.AddListener(Quit);
    }

    void Update()
    {
        zRot -= Time.deltaTime * 75;
        star.transform.rotation = Quaternion.Euler(0, 0, zRot);

        if (big == false)
        {
            textsizeF += Time.deltaTime * 10;
        }
        if (big == true)
        {
            textsizeF -= Time.deltaTime * 10;
        }
        textchange();
    }

    // Changes text size to give the main menu more life
    void textchange()
    {
        if (textsizeF <= 80)
        {
            big = false;
        }
        if (textsizeF >= 95)
        {
            big = true;
        }

        int textsizeI = Mathf.RoundToInt(textsizeF);
        maintext.fontSize = textsizeI;
    }

    // These handle the main menu buttons
    void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Player.score = 0;
    }
    
    void Controls()
    {
        SceneManager.LoadScene("Controls");
    }
    
    void Quit()
    {
        Application.Quit();
    }
}
