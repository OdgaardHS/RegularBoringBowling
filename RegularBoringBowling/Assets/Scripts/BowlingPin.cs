using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    bool isFallen = false;
    
    private Vector3 ResetPosition;
    private Quaternion ResetRotation;
    Rigidbody rigidBody;

    AudioSource audioSource;

    private int arrayMax;
    public int soundToPlay;

    [SerializeField] private AudioClip[] arrayPhysicSounds;

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

            if (angle >= 50)
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


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BowlingPin" || collision.gameObject.tag == "Ammunition" && arrayPhysicSounds.Length > 0)
        {
            audioSource = collision.gameObject.GetComponent<AudioSource>();
            arrayMax = arrayPhysicSounds.Length;
            soundToPlay = Random.Range(0, arrayMax);
            audioSource.clip = arrayPhysicSounds[soundToPlay];

            audioSource.volume = Mathf.Clamp01(collision.relativeVelocity.magnitude / 15);

            if (collision.relativeVelocity.magnitude > 1)
                audioSource.Play();
        }
    }


}
