using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class VolumeTest
{
    private SettingsManager settingsManager;

    int min = -80;
    int max = 0;
    
    [SetUp]
    public void SetUp()
    {
        GameObject setM = new GameObject();
        settingsManager = setM.AddComponent<SettingsManager>();
    }

    [UnityTest]
    public IEnumerator VolumeBoundaryTestIncrease()
    {
        float volume = 1;
        settingsManager.SetVolume(volume);
        Assert.That(volume <= max);
        yield return null;
    }

    [UnityTest]
    public IEnumerator VolumeBoundaryTestDecrease()
    {
        float volume = -81;
        settingsManager.SetVolume(volume);
        Assert.That(volume >= min);
        yield return null;
    }

    [UnityTest]
    public IEnumerator VolumeStressTestIncrease()
    {
        float volume = 50000;
        settingsManager.SetVolume(volume);
        Assert.That(volume <= max);
        yield return null;
    }

    [UnityTest]
    public IEnumerator VolumeStressTestDecrease()
    {
        float volume = -50000;
        settingsManager.SetVolume(volume);
        Assert.That(volume >= min);
        yield return null;
    }
}
