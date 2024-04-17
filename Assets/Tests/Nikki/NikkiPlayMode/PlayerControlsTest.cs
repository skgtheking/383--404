using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerControlsTest
{
    //Reference to PlayerControl component attached to the test GameObject
    private PlayerControl player;

    [SetUp]
    public void Setup()
    {
        //Create a new GameObject and add the PlayerControl component to it for testing
        GameObject playerObject = new GameObject();
        player = playerObject.AddComponent<PlayerControl>();
    }

    [UnityTest]
    public IEnumerator PlayerMovesCorrectly()
    {
        //SetUp intial position & movement
        Vector2 initialPosition = player.transform.position;
        Vector2 movement = new Vector2(1f, 0f);

        //Simulate player Input
        player.UpdateInput(movement);

        //Wait for one frame
        yield return null;

        // Check if player has moved
        Assert.AreNotEqual(initialPosition, player.transform.position);

        // Check if player has moved in the correct direction
        Assert.AreEqual(player.transform.position, initialPosition + movement * player.GetMoveSpeed() * Time.fixedDeltaTime);

    }


    [UnityTest]
    public IEnumerator PlayerAnimationUpdates()
    {
        // Set up movement for testing animation
        Vector2 movement = new Vector2(1f, 0f);

        // Simulate player input
        player.UpdateInput(movement);

        // Wait for one frame
        yield return null;

        // Check if animation parameters are set correctly
        Assert.AreEqual(player.animator.GetFloat("Horizontal"), movement.x);
        Assert.AreEqual(player.animator.GetFloat("Vertical"), movement.y);
        Assert.AreEqual(player.animator.GetFloat("Speed"), movement.sqrMagnitude);
    }

    [TearDown]
    public void Teardown()
    {
        // Clean up after the test
        GameObject.Destroy(player.gameObject);
    }
}
