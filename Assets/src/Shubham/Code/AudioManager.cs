using Unity.VisualScripting;
using UnityEngine;

public class AudioManager: MonoBehaviour{
    private static AudioManager instance;
    public static AudioManager Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<AudioManager>();
                if(instance == null){
                    GameObject obj = new GameObject();
                    obj.name = typeof(AudioManager).Name;
                    instance = obj.AddComponent<AudioManager>();
                }
            }

            return instance;
        }
    }

    public AudioSource backgroundMusicSource;
    public AudioSource walkingGrassSource;
    public AudioSource walkingWoodSource;
    public AudioSource monsterRoarSource;
    public AudioSource walkingConcreteSource;
    public AudioSource fireBurningSource;
    public AudioSource victorySoundSource;
    public AudioSource defeatSoundSource;

    private void Start() {
        backgroundMusicSource = GetComponent<AudioSource>();
        walkingGrassSource = GetComponent<AudioSource>();
        walkingWoodSource = GetComponent<AudioSource>();
        monsterRoarSource = GetComponent<AudioSource>();
        walkingConcreteSource = GetComponent<AudioSource>();
        fireBurningSource = GetComponent<AudioSource>();
        victorySoundSource = GetComponent<AudioSource>();
        defeatSoundSource = GetComponent<AudioSource>();
    }

    // Functions to play sound
    public void PlayBackgroundMusic(AudioClip bgm){
        backgroundMusicSource.clip = bgm;
        backgroundMusicSource.Play();
    }

    public void PlayWalkingGrassSound(AudioClip grass){
        walkingGrassSource.clip = grass;
        walkingGrassSource.Play();
    }

    public void PlayWalkingWoodSound(AudioClip wood){
        walkingWoodSource.clip = wood;
        walkingWoodSource.Play();
    }

    public void PlayMonsterRoarSound(AudioClip roar){
        monsterRoarSource.clip = roar;
        monsterRoarSource.Play();
    }

    public void PlayWalkingConcreteSound(AudioClip concrete){
        walkingConcreteSource.clip = concrete;
        walkingConcreteSource.Play();
    }

    public void PlayFireBurningSound(AudioClip fire){
        fireBurningSource.clip = fire;
        fireBurningSource.Play();
    }

    public void PlayVictorySound(AudioClip victory){
        victorySoundSource.clip = victory;
        victorySoundSource.Play();
    }

    public void PlayDefeatSound(AudioClip defeat){
        defeatSoundSource.clip = defeat;
        defeatSoundSource.Play();
    }
}