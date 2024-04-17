using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AddItems
{
    private InventoryManager inventoryManager;
    [SetUp]
    public void SetUp()
    {
        GameObject Inventory = new GameObject();
        inventoryManager = Inventory.GetComponent<InventoryManager>();
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator AddItemsWithEnumeratorPasses()
    {
        Sprite heart = Resources.Load<Sprite>("heart");
        int count = 0;

        for(int i = 0; i < 7; i++)
        {
            inventoryManager.AddItem("lol", 1, heart, "lol");
            count++;
        }
        Assert.That(count < 6);
        yield return null;
    }
}
