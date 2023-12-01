using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PinResetScript : MonoBehaviour
{
    public GameObject pinParent;

    public GameObject BowlingPinsWorking;

    public Transform spawnPosition;


    public void instantiatePins()
    {
        if (pinParent != null)
        {
            Destroy(pinParent);
            pinParent = Instantiate(BowlingPinsWorking, spawnPosition);
        }
        
        
    }


}