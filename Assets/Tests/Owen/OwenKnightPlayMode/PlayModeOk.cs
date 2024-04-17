using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayModeOk
{

    private HealthBar healthBar;

    [SetUp]
    public void SetUp()
    {
        GameObject HB = new GameObject();
        healthBar = HB.AddComponent<HealthBar>();
    }
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PlayModeOkWithEnumeratorPasses()
    {
        int initialHealth = 100;
        healthBar.SetMaxHealth(initialHealth);
        healthBar.SetHealth(initialHealth + 1);
        Assert.That(initialHealth <= 100);
        yield return null;
    }
}
