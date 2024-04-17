using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(AudioManager).Name;
                    instance = obj.AddComponent<AudioManager>();
                }
            }

            return instance;
        }
    }

    private AudioSource backgroundMusicSource;
    private AudioSource walkingGrassSource;
    private AudioSource walkingWoodSource;
    private AudioSource monsterRoarSource;
    private AudioSource walkingConcreteSource;
    private AudioSource fireBurningSource;
    private AudioSource victorySoundSource;
    private AudioSource defeatSoundSource;

    private void Start()
    {
        // Get references to the AudioSource components by tag
        backgroundMusicSource = GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<AudioSource>();
        Debug.Log(backgroundMusicSource ? "BackgroundMusicSource initialized" : "BackgroundMusicSource not found");

        walkingGrassSource = GameObject.FindGameObjectWithTag("WalkingGrass").GetComponent<AudioSource>();
        Debug.Log(walkingGrassSource ? "WalkingGrassSource initialized" : "WalkingGrassSource not found");

        walkingWoodSource = GameObject.FindGameObjectWithTag("WoodSound").GetComponent<AudioSource>();
        Debug.Log(walkingWoodSource ? "WalkingWoodSource initialized" : "WalkingWoodSource not found");


        walkingConcreteSource = GameObject.FindGameObjectWithTag("ConcreteSound").GetComponent<AudioSource>();
        Debug.Log(walkingConcreteSource ? "WalkingConcreteSource initialized" : "WalkingConcreteSource not found");

        fireBurningSource = GameObject.FindGameObjectWithTag("FireSound").GetComponent<AudioSource>();
        Debug.Log(fireBurningSource ? "FireBurningSource initialized" : "FireBurningSource not found");

        

    }

    // Functions to play sound
    public void PlayBackgroundMusic()
    {
        backgroundMusicSource.Play();
    }

    public void PlayWalkingGrassSound()
    {
        walkingGrassSource.Play();
    }

    public void PlayWalkingWoodSound()
    {
        //Stop Grass Sound
        walkingGrassSource.Stop();
        walkingWoodSource.Play();
    }

    public void PlayMonsterRoarSound()
    {
        monsterRoarSource.Play();
    }

    public void PlayWalkingConcreteSound()
    {
        //Stop Wood Source
        walkingWoodSource.Stop();
        walkingConcreteSource.Play();
    }

    public void PlayFireBurningSound()
    {
        //Stop wood sound
        if (fireBurningSource != null)
        {
            walkingWoodSource.Stop();
            fireBurningSource.Play();
            Debug.Log("Played Fire Burning Sound");
        }
        else
        {
            Debug.LogError("FireBurningSource is not initialized");
        }

    }

    public void PlayVictorySound()
    {
        victorySoundSource.Play();
    }

    public void PlayDefeatSound()
    {
        defeatSoundSource.Play();
    }
}
