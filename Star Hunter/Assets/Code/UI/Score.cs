using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Variables
    [SerializeField] Text score;
    [SerializeField] GameObject player;

    void Update()
    {
        score.text = Player.score.ToString();
    }
}
