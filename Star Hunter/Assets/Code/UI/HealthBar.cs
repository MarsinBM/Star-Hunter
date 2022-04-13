using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Variables
    [SerializeField] Slider hpslider;
    [SerializeField] GameObject player;
   
    void Update()
    {
        Player healthscript = player.GetComponent<Player>();
        hpslider.value = healthscript.health;
    }
}
