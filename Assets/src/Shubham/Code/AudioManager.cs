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
        walkingGrassSource = GameObject.FindGameObjectWithTag("WalkingGrass").GetComponent<AudioSource>();
        walkingWoodSource = GameObject.FindGameObjectWithTag("WoodSound").GetComponent<AudioSource>();
        monsterRoarSource = GameObject.FindGameObjectWithTag("MonsterRoar").GetComponent<AudioSource>();
        walkingConcreteSource = GameObject.FindGameObjectWithTag("ConcreteSound").GetComponent<AudioSource>();
        fireBurningSource = GameObject.FindGameObjectWithTag("FireSound").GetComponent<AudioSource>();
        victorySoundSource = GameObject.FindGameObjectWithTag("VictorySound").GetComponent<AudioSource>();
        defeatSoundSource = GameObject.FindGameObjectWithTag("DefeatSound").GetComponent<AudioSource>();
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
        walkingWoodSource.Stop();
        fireBurningSource.Play();
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
