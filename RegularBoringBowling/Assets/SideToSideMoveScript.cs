using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSideMoveScript : MonoBehaviour
{
    public float distanceToCover = 3;
    public float speed = 3;

    public Transform GameObject;

    private Vector3 startingPosition;

    void Update()
    {
        startingPosition = GameObject.position;
        Vector3 v = startingPosition;
        v.x += distanceToCover * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}