using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LevelChanger : MonoBehaviour
{
    // Call for animator object in Unity (insert the animator called 'LevelChanger' into inspector)
    public Animator animator;

    // Variable for loading certain level (based on level index)
    private int levelToLoad;

    // bool to unlock test conditions
    [Header ("Test Load Scene Function:")]
    [SerializeField] bool ReloadSceneTest = true;
    [SerializeField] bool NewSceneTest = false;

    //Determine current scene
        [Header ("Active Scene Bool:")]
        [SerializeField] public bool Scene1Active = true;
        [SerializeField] public bool Scene2Active = false;
        [SerializeField] public bool Scene3Active = false;

            // Scene 1
            // Catch goal bools from other script
            [Header ("Test Scene 1 goals:")]
            [SerializeField] public bool WoodChopped;
            [SerializeField] public bool WoodStacked;
            [HideInInspector] public bool OpeningDoor;

            // Scene 2
            // Catch goal bools from other script
            [Header ("Test Scene 2 goals:")]
            [SerializeField] public bool AllItemGathered;

            // Scene 3 
            // Catch goal bools from other script
            [Header ("Test Scene 3 goals:")]
            [SerializeField] public bool StonesPlaced;
            [SerializeField] public bool WoodPlacedOnPyre;
            [FormerlySerializedAs("TorchLit")] [SerializeField] public bool FuneralPyreLit;

            private int countStonesPlaced;
            private int countWoodPlaced;

    void Awake()
    {
        // Managing bools when loading LevelChanger object in new scenes.
        if (Scene1Active == true)
        {
            WoodStacked = false;
            WoodChopped = false;
            OpeningDoor = false;
            Debug.Log("Scene 1 Is Now Active!");
        }

        if (Scene2Active == true)
        {
            OpeningDoor = false;
            AllItemGathered = false;
            Debug.Log("Scene 2 Is Now Active!");
        }

        if (Scene3Active == true)
        {
            StonesPlaced = false;
            FuneralPyreLit = false;
            Debug.Log("Scene 3 Is Now Active!");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Testing();

        // Conditions for interactive experience
        
        if (Scene1Active == true)
        {
            if (OpeningDoor == true)
            {
                FadeToNextLevel();
                Scene2Active = true;
                Scene1Active = false;
            }
        }

        if (Scene2Active == true)
        {
            if (OpeningDoor == true)
            {
                FadeToNextLevel();
                Scene3Active = true;
                Scene2Active = false;
            }
        }

        if (Scene3Active == true)
        {
            if(StonesPlaced == true && FuneralPyreLit == true)
            {
                Debug.Log("Experience Is Over!");
            }
        }
        
        
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Method for running animation and setting the level index to load.
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    // Function used as animation event
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Testing()
    {
        // These conditions only apply when testing. 
        if (Input.GetMouseButtonDown(0) && ReloadSceneTest == true && NewSceneTest == false)
        {
            FadeToLevel(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Reloading Same Scene!");
        }

        if (Input.GetMouseButtonDown(0) && NewSceneTest == true && ReloadSceneTest == false)
        {
            FadeToNextLevel();
            Debug.Log("Entering New Scene!");
        }

        else if (NewSceneTest == true && ReloadSceneTest == true && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Can't Reload And Start New Scene At The Same Time!");
        }

    }

    public void CountStonePlacements()
    {
        countStonesPlaced++;
        Debug.Log("Stones placed: " + countStonesPlaced);

        if (countStonesPlaced == 12)
        {
            StonesPlaced = true;
        }
    }
    
    public void CountWooodPlacements()
    {
        countWoodPlaced++;
        Debug.Log("Wood placed: " + countWoodPlaced);
        
        if (countWoodPlaced == 6)
        {
            WoodPlacedOnPyre = true;
        }
    }

    public void DecrementStoneCount()
    {
        countStonesPlaced--;
    }
    
    public void DecrementWoodCount()
    {
        countWoodPlaced--;
    }

}
