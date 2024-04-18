using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerControlsTest
{
    private GameObject gameObject;
    //Reference to PlayerControl component attached to the test GameObject
    private PlayerControl player;

    [SetUp]
    public void Setup()
    {
        //Create a new GameObject and add the PlayerControl component to it for testing
        gameObject = GameObject.Instantiate(new GameObject());
        player = gameObject.AddComponent<PlayerControl>();
    }

    [UnityTest]
    public IEnumerator HasRigidBody2d()
    {
        yield return new WaitForSeconds(0.1f);
        Assert.NotNull(player.GetComponent<Rigidbody2D>(), "player has Rigidbody2D attached");
    }


    [UnityTest]
    public IEnumerator PlayerMovesAfterGameStarts()
    {
        Vector3 position = player.transform.position;
        yield return new WaitForSeconds(0.1f);

        Vector3 newPosition = player.transform.position;
        Assert.AreNotEqual(newPosition, position, "Movement Test Passed. Player object moved from" + position + "to" + newPosition);

    }

    [TearDown]
    public void Teardown()
    {
        // Clean up after the test
        GameObject.Destroy(gameObject);
    }
}
