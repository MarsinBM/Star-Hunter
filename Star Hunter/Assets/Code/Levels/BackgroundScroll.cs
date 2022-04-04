using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    // Variables
    private float parralax = 3;

    void Update()
    {
        MeshRenderer space = GetComponent<MeshRenderer>();

        Material main = space.material;

        Vector2 offset = main.mainTextureOffset;

        offset.x = transform.position.x / transform.localScale.x / parralax;
        offset.y = transform.position.y / transform.localScale.y / parralax;

        main.mainTextureOffset = offset;
    }
}
