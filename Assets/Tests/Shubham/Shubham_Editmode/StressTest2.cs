// StressTest2.cs

using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StressTest2
{
    [Test]
    public void TestFireBurningSound()
    {
        GameObject audioManagerObj = new GameObject();
        audioManagerObj.AddComponent<AudioManager>();
        AudioManager audioManager = AudioManager.Instance;

        // Null check for AudioManager
        Assert.IsNotNull(audioManager, "AudioManager is null.");

        // Test the PlayFireBurningSound() function
        audioManager.PlayFireBurningSound();
    }
}
