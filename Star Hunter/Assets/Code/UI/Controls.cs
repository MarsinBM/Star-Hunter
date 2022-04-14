using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour
{
    // Variables
    [SerializeField] Button toMenu;
    
    void Start()
    {
        toMenu.onClick.AddListener(ToMenu);
    }

    void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Player.score = 0;
    }
}
