using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
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
