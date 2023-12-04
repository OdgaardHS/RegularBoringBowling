using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int ThrowsLeft = 2;
    public static int PlayerScore = 0;

    public static bool pinsReset = false;

    // Update is called once per frame
    void Update()
    {
        if (ThrowsLeft <= 0)
        {
            StartCoroutine(waitTillReset());
            
            ThrowsLeft = 2;
        }
    }

    IEnumerator waitTillReset()
    {
        yield return new WaitForSeconds(5);

        pinsReset = true;

        yield return new WaitForSeconds(2);

        pinsReset = false;
    }
}
