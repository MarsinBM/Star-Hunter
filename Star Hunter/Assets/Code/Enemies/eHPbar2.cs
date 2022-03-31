using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eHPbar2 : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject enemyTWO;

    private Vector3 localScale;

    Quaternion rotation;

    void Start()
    {
        localScale = transform.localScale;
        rotation = transform.rotation;
    }

    void Update()
    {
        enemy2 escript = enemyTWO.GetComponent<enemy2>();
        localScale.x = escript.health;
        transform.localScale = localScale;
    }

    void LateUpdate()
    {
        transform.rotation = rotation;
    }
}
