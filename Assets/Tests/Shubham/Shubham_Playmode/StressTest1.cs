using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StressTest1
{
    private GameObject backgroundMusicObj;
    private GameObject walkingGrassObj;
    private GameObject walkingWoodObj;
    private GameObject monsterRoarObj;
    private GameObject walkingConcreteObj;
    private GameObject fireBurningObj;
    private GameObject victorySoundObj;
    private GameObject defeatSoundObj;

    private AudioManager audioManager;

    [SetUp]
    public void SetUp()
    {
        // Create GameObjects for each AudioSource
        backgroundMusicObj = new GameObject("BackgroundMusicSource");
        walkingGrassObj = new GameObject("WalkingGrassSource");
        walkingWoodObj = new GameObject("WalkingWoodSource");
        monsterRoarObj = new GameObject("MonsterRoarSource");
        walkingConcreteObj = new GameObject("WalkingConcreteSource");
        fireBurningObj = new GameObject("FireBurningSource");
        victorySoundObj = new GameObject("VictorySoundSource");
        defeatSoundObj = new GameObject("DefeatSoundSource");

        // Add AudioSource components to each GameObject
        backgroundMusicObj.AddComponent<AudioSource>();
        walkingGrassObj.AddComponent<AudioSource>();
        walkingWoodObj.AddComponent<AudioSource>();
        monsterRoarObj.AddComponent<AudioSource>();
        walkingConcreteObj.AddComponent<AudioSource>();
        fireBurningObj.AddComponent<AudioSource>();
        victorySoundObj.AddComponent<AudioSource>();
        defeatSoundObj.AddComponent<AudioSource>();

        // Assign tags to each GameObject
        backgroundMusicObj.tag = "BackgroundMusic";
        walkingGrassObj.tag = "WalkingGrass";
        walkingWoodObj.tag = "WoodSound";
        monsterRoarObj.tag = "MonsterRoar";
        walkingConcreteObj.tag = "ConcreteSound";
        fireBurningObj.tag = "FireSound";
        victorySoundObj.tag = "VictorySound";
        defeatSoundObj.tag = "DefeatSound";

        // Create an instance of AudioManager
        audioManager = AudioManager.Instance;
    }

    [UnityTest]
    public IEnumerator TestMultipleAudioPlayback()
    {
        audioManager.PlayBackgroundMusic();
        //wait for 2s and call other functions from audiomanager
        audioManager.PlayBackgroundMusic();
        yield return new WaitForSeconds(0.5f);
        audioManager.PlayFireBurningSound();
        yield return new WaitForSeconds(0.3f);
        // Test audio playback functionalities here
        yield return null;
    }
}
