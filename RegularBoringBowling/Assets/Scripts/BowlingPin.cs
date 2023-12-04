using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    bool isFallen = false;
    
    private Vector3 ResetPosition;
    private Quaternion ResetRotation;
    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        ResetPosition = transform.position;
        ResetRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFallen)
        {
            float angle = Quaternion.Angle(ResetRotation, transform.rotation);

            if (angle >= 75)
            {
                Score.PlayerScore++;
                Score.PinsSinceRoundStart++;
                isFallen = true;

                Debug.Log($"TotalScore: {Score.PlayerScore} Round Score: {Score.PinsSinceRoundStart}");
            }
        }
        
        if (Score.pinsReset)
        {
            transform.position = ResetPosition;
            transform.rotation = ResetRotation;
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;

            isFallen = false;
        }
    }
}
