using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateScript : MonoBehaviour
{
    public GameObject discoBallParent;

    // Update is called once per frame
    void Update()
    {
        discoBallParent.transform.Rotate (Vector3.down * 50 * Time.deltaTime, Space.World);
    }
}
