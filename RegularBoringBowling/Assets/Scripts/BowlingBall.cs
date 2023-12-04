using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    private Vector3 ResetPosition;
    private Quaternion ResetRotation;
    Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        ResetPosition = transform.position;
        ResetRotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ResetZone"))
        {
            Score.ThrowsLeft--; // Counts amount of throws
            
            // Resets the position and velocity of the ball
            transform.position = ResetPosition;
            transform.rotation = ResetRotation;
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
        }
    }
}
