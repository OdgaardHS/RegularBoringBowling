using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static int ThrowsLeft = 2;
    public static int PlayerScore = 0;

    public static bool pinsReset = false;
    private bool haveStriked = false;

    public static int PinsSinceRoundStart = 0;
    private int CurrentRound = 1;

    public TMP_Text Round1;
    public TMP_Text Round2;
    public TMP_Text Round3;
    public TMP_Text Round4;
    public TMP_Text Round5;
    public TMP_Text Total;

    // Update is called once per frame
    void Update()
    {
        if (ThrowsLeft <= 0 && !haveStriked)
        {
            StartCoroutine(waitTillReset());
            
            ThrowsLeft = 2;
        }

        if (PinsSinceRoundStart >= 10 && !haveStriked && ThrowsLeft >= 1)
        {
            haveStriked = true;
            Debug.Log("The player have striked!");

            StartCoroutine(waitTillReset());

            ThrowsLeft = 2;
        }

        switch (CurrentRound)
        {
            case 1:
                Round1.text = PinsSinceRoundStart.ToString();
                break;
            case 2:
                Round2.text = PinsSinceRoundStart.ToString();
                break;
            case 3:
                Round3.text = PinsSinceRoundStart.ToString();
                break;
            case 4:
                Round4.text = PinsSinceRoundStart.ToString();
                break;
            case 5:
                Round5.text = PinsSinceRoundStart.ToString();
                break;
        }

        Total.text = PlayerScore.ToString();
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
