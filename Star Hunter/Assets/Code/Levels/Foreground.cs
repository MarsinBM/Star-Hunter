using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foreground : MonoBehaviour
{
    // Variables
    [SerializeField] Transform Pcamera;
    private Vector3 lastCamPos;

    private float parallax = 0.2f; 

    void Start()
    {
        Pcamera = Camera.main.transform;
        lastCamPos = Pcamera.position;
    }

    
    void LateUpdate()
    {
        Vector3 deltaMovement = Pcamera.position - lastCamPos;
        transform.position += deltaMovement * parallax;
        lastCamPos = Pcamera.position;
        
    }
}
