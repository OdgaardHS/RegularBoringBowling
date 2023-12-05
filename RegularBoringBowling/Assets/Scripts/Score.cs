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
    public static bool ballsReset = false;

    private bool haveStriked = false;
    private bool isReseting = false;

    public static int PinsSinceRoundStart = 0;
    private int CurrentRound = 1;

    public TMP_Text Round1;
    public TMP_Text Round2;
    public TMP_Text Round3;
    public TMP_Text Round4;
    public TMP_Text Round5;
    public TMP_Text Total;
    public TMP_Text ThrowsLeftUI;

    public GameObject Warning;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ThrowsLeft <= 0 && !haveStriked && !isReseting)
        {
            isReseting = true;
            StartCoroutine(waitTillReset());
        }

        if (PinsSinceRoundStart >= 10 && !haveStriked && ThrowsLeft >= 1 && !isReseting)
        {
            isReseting = true;
            haveStriked = true;
            Debug.Log("The player have striked!");

            audioSource.Play();

            StartCoroutine(waitTillReset());
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
        ThrowsLeftUI.text = $"Throws Left: {ThrowsLeft.ToString()}";
    }

    public void ResetBalls()
    {
        StartCoroutine(ballReset());
    }

    public void ResetPins()
    {
        StartCoroutine(pinReset());
    }

    public void ResetPoints()
    {
        PlayerScore = 0;
        PinsSinceRoundStart = 0;
        CurrentRound = 1;
        ThrowsLeft = 2;
        ResetPins();

        Round1.text = 0.ToString();
        Round2.text = 0.ToString();
        Round3.text = 0.ToString();
        Round4.text = 0.ToString();
        Round5.text = 0.ToString();
    }

    IEnumerator waitTillReset()
    {
        isReseting = true;
        Warning.SetActive(true);
        yield return new WaitForSeconds(4);

        pinsReset = true;
        ThrowsLeft = 2;

        yield return new WaitForSeconds(1);
        Warning.SetActive(false);
        
        pinsReset = false;

        PinsSinceRoundStart = 0;
        CurrentRound++;
        isReseting = false;
        haveStriked = false;
        Debug.Log($"Starting Round: {CurrentRound}");
    }

    IEnumerator pinReset()
    {
        pinsReset = true;
        yield return new WaitForSeconds(1);
        pinsReset = false;
    }

    IEnumerator ballReset()
    {
        ballsReset = true;
        yield return new WaitForSeconds(1);
        ballsReset = false;
    }
}
