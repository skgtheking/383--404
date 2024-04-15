// BoundaryTest.cs

using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BoundaryTest
{
    [Test]
    public void TestAudioManagerInitialization()
    {
        GameObject audioManagerObj = new GameObject();
        audioManagerObj.AddComponent<AudioManager>();
        
        Assert.IsNotNull(AudioManager.Instance, "AudioManager not initialized properly.");
    }
}
