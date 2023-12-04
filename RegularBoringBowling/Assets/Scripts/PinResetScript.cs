using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class PinResetScript : MonoBehaviour
{
    public GameObject pinParent;

    public GameObject BowlingPinsWorking;

    public Transform spawnPosition;

    public Collider TriggerZone;


 

    private void OnTriggerEnter(Collider other)
    {
       SceneManager.LoadScene("BowlingScene");
    }


}