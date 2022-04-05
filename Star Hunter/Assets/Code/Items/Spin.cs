using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    // Variables
    private float zRot;

    void Update()
    {
        zRot -= Time.deltaTime * 75;
        transform.rotation = Quaternion.Euler(0,0,zRot);
    }
}
