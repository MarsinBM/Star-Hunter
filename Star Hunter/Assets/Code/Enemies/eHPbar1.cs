using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eHPbar1 : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject enemyONE;

    private Vector3 localScale;
    
    void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {
        enemy1 escript = enemyONE.GetComponent<enemy1>();
        localScale.x = escript.health;
        transform.localScale = localScale;
        // ROTATION NEEDS TO BE FIXED IN PLACE SO IT DOESNT ROTATE WITH OBJECT
    }
}
