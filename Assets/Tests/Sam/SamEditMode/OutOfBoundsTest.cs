using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class OutOfBoundsTest
{
    private Enemy enemy;
    [Test]

    public void OutOfBoundsTestSimplePasses()
    {

        
        var player = new GameObject();
        var enemyGO = new GameObject();
        enemy = enemyGO.AddComponent<Enemy>();

        enemy.movespeed = 100f; // Initial speed for testing
        enemy.viewdistance = 100f; // Initial view distance for testing


        //Enemy position cannot equal player position if they are in seperate rooms, if this test passes then the enemy is so fast that it passes through its room to get to the player
        
        Assert.AreEqual(enemy.transform.position.x, player.transform.position.x);

    }


}
