using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        HealthBar healthbar = new HealthBar();
        int max = 4;
        int value = 3;
        healthbar.SetMaxHealth(max);
        healthbar.SetHealth(value);
        Assert.IsTrue(value < max);
        yield return null;
    }
}
