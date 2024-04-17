// StressTest1.cs

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StressTest1
{
    [UnityTest]
    public IEnumerator TestMultipleAudioPlayback()
    {
        AudioManager audioManager = AudioManager.Instance;

        // Simulate multiple playbacks
        for (int i = 0; i < 10; i++)
        {
            audioManager.PlayWalkingGrassSound();
            yield return null;
        }
    }
}
