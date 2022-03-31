using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eHPbar1 : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject enemyONE;

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
    }

    void LateUpdate()
    {
        transform.rotation = rotation;
    }
}
