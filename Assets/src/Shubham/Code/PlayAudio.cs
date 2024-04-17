using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public LevelManager levelManager;
    public SoundPlayer soundPlayer;
    private float previousLevel = 0;

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        if (levelManager == null)
        {
            Debug.LogError("levelManager is not assigned in PlayAudio script.");
            return;
        }

        if (soundPlayer == null)
        {
            soundPlayer = new GrassSoundPlayer();
        }
    }

    void Update()
    {
        if (levelManager == null)
        {
            Debug.LogError("levelManager is not assigned in PlayAudio script.");
            return;
        }

        if (soundPlayer == null)
        {
            soundPlayer = new GrassSoundPlayer();
        }

        float currentLevel = levelManager.currentLevel();

        if (currentLevel!= previousLevel)
        {
            switch (currentLevel)
            {
                case 1:
                    soundPlayer = new GrassSoundPlayer();
                    break;
                case 2:
                    soundPlayer = new WoodSoundPlayer();
                    break;
                case 3:
                    soundPlayer = new FireSoundPlayer();
                    break;
                default:
                    // Handle additional levels if needed
                    break;
            }

            soundPlayer.PlaySound();
            previousLevel = currentLevel;
        }
    }
}