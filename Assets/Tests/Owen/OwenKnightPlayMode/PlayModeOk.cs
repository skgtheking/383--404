using System.Collections;
using System.Collections.Generic;
using System.Xml;
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
    public IEnumerator HealthBarBoundaryIncrease()
    {
        int initialHealth = 101;
        int maxHealth = 100;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(initialHealth);
        Assert.That(initialHealth <= maxHealth);
        yield return null;
    }

    [UnityTest]
    public IEnumerator HealthBarBoundaryDecrease()
    {
        int intialHealth = -1;
        int minHealth = 0;
        healthBar.SetMaxHealth(100);
        healthBar.SetHealth(intialHealth);
        Assert.That(intialHealth >= minHealth);
        yield return null;
    }

    [UnityTest]
    public IEnumerator HealthBarStressIncrease()
    {
        int intialHealth = 50000;
        int maxHealth = 100;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(intialHealth);
        Assert.That(intialHealth <= maxHealth);
        yield return null;
    }

    [UnityTest]
    public IEnumerator HealthBarStressDecrease()
    {
        int intialHealth = -50000;
        int minHealth = 0;
        healthBar.SetMaxHealth(100);
        healthBar.SetHealth(intialHealth);
        Assert.That(intialHealth >= minHealth);
        yield return null;
    }
}
