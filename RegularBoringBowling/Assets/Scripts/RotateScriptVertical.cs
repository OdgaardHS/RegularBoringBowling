using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScriptVertical : MonoBehaviour
{
    public int lightSpeed;

    public GameObject TransformParent;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate (Vector3.left * lightSpeed * Time.deltaTime, Space.World);
    }
}
