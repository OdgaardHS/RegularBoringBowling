using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BazookaScript : MonoBehaviour
{
    //bools
    public bool bazookaBeingHeld;
    public bool bazookaIsLoaded;
    
    //colliders
    [SerializeField] private Collider reloadCollider;
    
    //Gameobjects
    private GameObject ammunitionToShoot;
    
    //Transforms
    [SerializeField] private Transform shootingTransform;
    [SerializeField] private Transform outOfSightPosition;
    [SerializeField] private Transform bazookaParent;

    private GameObject ammoInstance;
    private Collider thisGameobjectCollider;
    
    //Ints
    [SerializeField] private int shootingForce = 3000;
    
    
    [SerializeField] private InputActionReference triggerButtonReference = null;
    
    [SerializeField] private AudioSource BazookaAudioSource;
    
    [SerializeField] private AudioClip[] arrayBazookaSounds; // The array controlling the sounds
    
    public int pickedSoundToPlay;
    
    private void Awake()
    {
        thisGameobjectCollider = gameObject.GetComponent<Collider>();
        triggerButtonReference.action.Enable();
        triggerButtonReference.action.started += ShootBazooka;
        triggerButtonReference.action.performed += ShootBazooka;
        triggerButtonReference.action.canceled += ShootBazooka;
    }
    
    private void OnDestroy()
    {
        triggerButtonReference.action.started -= ShootBazooka;
        triggerButtonReference.action.performed -= ShootBazooka;
        triggerButtonReference.action.canceled -= ShootBazooka;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ammunition") && bazookaIsLoaded == false)
        {
            gameObject.GetComponent<Collider>().isTrigger = false;
            Debug.Log("AMMO");
            //other.gameObject.transform.position = outOfSightPosition.position;
            ammunitionToShoot = other.gameObject;
            ammoInstance = Instantiate(ammunitionToShoot, shootingTransform.position, shootingTransform.rotation);
            Destroy(other.gameObject);
            ammoInstance.SetActive(false);
            bazookaIsLoaded = true;
            PlayBazookaSound(0);
        }
    }

    public void bazookaIsBeingHeldMethod()
    {
        bazookaBeingHeld = true;
        //audiosource.clip.play //Sound of loading bowling ball into bazooka
    }
    
    public void bazookaNotBeingHeldMethod()
    {
        bazookaBeingHeld = false;
        //audiosource.clip.play //Sound of loading bowling ball into bazooka
    }

    public void ShootBazooka(InputAction.CallbackContext context)
    {
        if (context.performed && bazookaIsLoaded == true && bazookaBeingHeld == true)
        {
            //Rigidbody ammoRb;
            //var ammoInstance = Instantiate(ammunitionToShoot, shootingTransform.position, shootingTransform.rotation);
            ammoInstance.transform.position = shootingTransform.position; 
            ammoInstance.SetActive(true);
            var ammoRb = ammoInstance.GetComponent<Rigidbody>();
            ammoRb.useGravity = true;
            ammoRb.constraints = RigidbodyConstraints.None;
            ammoRb.AddForce(transform.forward * shootingForce);
            
            PlayBazookaSound(1); //Play sound of a loud boom which signifies that you just fired the bazooka

            bazookaIsLoaded = false;
            StartCoroutine(EnableColliderAgain());
            Debug.Log("SHOOT BAZOOKA"); 
        }
    }
    
    private void PlayBazookaSound(int pickedSoundToPlay)
    {
        if (arrayBazookaSounds.Length > 0)
        {
            BazookaAudioSource.clip = arrayBazookaSounds[pickedSoundToPlay];
            BazookaAudioSource.Play();
        }
        
    }

    private IEnumerator EnableColliderAgain()
    {
        yield return new WaitForSeconds(0.5f);
        thisGameobjectCollider.isTrigger = true;

    }
    
}
