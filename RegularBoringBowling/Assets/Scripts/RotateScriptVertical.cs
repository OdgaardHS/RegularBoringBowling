using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScriptVertical : MonoBehaviour
{
    public GameObject TransformParent;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate (Vector3.left * 50 * Time.deltaTime, Space.World);
    }
}
