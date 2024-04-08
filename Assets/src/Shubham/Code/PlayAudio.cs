using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioManager audioManager;
    public LevelManager levelManager;

    private int previousLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the current level has changed
        if ((int)levelManager.currentLevel() != previousLevel)
        {
            // Get the current level
            int currentLevel = (int)levelManager.currentLevel();

            // Play different sounds based on the current level
            switch (currentLevel)
            {
                case 1:
                    audioManager.PlayWalkingGrassSound();
                    break;
                case 2:
                    audioManager.PlayWalkingWoodSound();
                    break;
                case 3:
                    
                    audioManager.PlayFireBurningSound();
                    break;
                default:
                    // Handle additional levels if needed
                    break;
            }

            // Update the previous level to the current level
            previousLevel = currentLevel;
        }
    }
}
