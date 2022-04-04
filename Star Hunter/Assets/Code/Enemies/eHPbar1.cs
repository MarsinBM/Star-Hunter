using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eHPbar1 : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject enemyONE;

    [SerializeField] SpriteRenderer hpbar;

    private Vector3 localScale;

    Quaternion rotation;
    
    void Start()
    {
        localScale = transform.localScale;
        rotation = transform.rotation;
    }

    void Update()
    {
        enemy1 escript = enemyONE.GetComponent<enemy1>();
        localScale.x = escript.health;
        transform.localScale = localScale;

        ColorChange();
        
    }

    void LateUpdate()
    {
        transform.rotation = rotation;
    }

    // Changes HP bar color depending on its state
    void ColorChange()
    {
        enemy1 escript = enemyONE.GetComponent<enemy1>();
        if (escript.idle == true)
        {
            hpbar.color = new Color(80,80,80);
        }
        else
        {
            hpbar.color = new Color(255, 0, 0);
        }
    }
}
