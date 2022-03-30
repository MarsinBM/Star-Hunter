using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eHPbar2 : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject enemyTWO;

    private Vector3 localScale;

    void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {
        enemy2 escript = enemyTWO.GetComponent<enemy2>();
        localScale.x = escript.health;
        transform.localScale = localScale;
    }
}
