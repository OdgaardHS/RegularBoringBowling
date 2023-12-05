using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    AudioSource audioSource;
    
    private Vector3 ResetPosition;
    private Quaternion ResetRotation;
    Rigidbody rigidBody;

    bool isRolling = false;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            isRolling = false;
            audioSource.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BowlingLane" && !isRolling)
        {
            isRolling = true;
            audioSource.Play();
        }
    }

    private void Update()
    {
        if (Score.ballsReset)
        {
            transform.position = ResetPosition;
            transform.rotation = ResetRotation;
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
            isRolling = false;
            audioSource.Stop();
        }
    }
}
