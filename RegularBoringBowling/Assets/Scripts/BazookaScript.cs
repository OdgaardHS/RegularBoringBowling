using System;
using System.Collections;
using System.Collections.Generic;
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
    
    
    [SerializeField] private InputActionReference triggerButtonReference = null;
    
    private void Awake()
    {
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

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ammunition"))
        {
            ammunitionToShoot = other.gameObject;
            bazookaLoaded();
        }
    }

    public void bazookaLoaded()
    {
        bazookaIsLoaded = true;
        //audiosource.clip.play //Sound of loading bowling ball into bazooka
    }

    public void ShootBazooka(InputAction.CallbackContext context)
    {
        if (context.performed && bazookaIsLoaded && bazookaBeingHeld)
        {
            var ammoInstance = Instantiate(ammunitionToShoot, shootingTransform);
                ammoInstance.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Force);
                
                //audiosource.clip.play //Play sound of a loud boom which signifies that you just fired the bazooka
        }
    }
    
}
