using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int ThrowsLeft = 2;
    public static int PlayerScore = 0;

    public static bool pinsReset = false;
    private bool haveStriked = false;

    public static int PinsSinceRoundStart = 0;
    private int CurrentRound = 1;

    // Update is called once per frame
    void Update()
    {
        if (ThrowsLeft <= 0 && !haveStriked)
        {
            StartCoroutine(waitTillReset());
            
            ThrowsLeft = 2;
        }

        if (PinsSinceRoundStart >= 10 && !haveStriked && ThrowsLeft == 1)
        {
            haveStriked = true;
            Debug.Log("The player have striked!");

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

        PinsSinceRoundStart = 0;
        CurrentRound++;
        Debug.Log($"Starting Round: {CurrentRound}");
    }
}
