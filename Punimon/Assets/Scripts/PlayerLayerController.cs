using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayerController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0f, 0f, transform.parent.transform.position.y);
    }
}
