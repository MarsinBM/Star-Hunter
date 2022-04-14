using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    // Variables
    [SerializeField] Image s1;
    [SerializeField] Image s2;
    [SerializeField] Image s3;

    void Start()
    {
        if (Player.score > 27 && Player.score < 140)
        {
            s1.color = new Color32(255, 255, 0, 255);
        }
        if (Player.score > 140 && Player.score < 225)
        {
            s1.color = new Color32(255, 255, 0, 255);
            s2.color = new Color32(255, 255, 0, 255);
        }
        if (Player.score >= 255)
        {
            s1.color = new Color32(255, 255, 0, 255);
            s2.color = new Color32(255, 255, 0, 255);
            s3.color = new Color32(255, 255, 0, 255);
        }
    }
}
