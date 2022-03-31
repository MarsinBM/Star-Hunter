using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Variables
    Quaternion rotation;

    void Start()
    {
        rotation = transform.rotation;
    }
   
    void LateUpdate()
    {
        transform.rotation = rotation;
    }
}
