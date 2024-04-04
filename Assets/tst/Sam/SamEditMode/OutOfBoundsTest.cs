using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class OutOfBoundsTest
{
    
    [Test]

    public void OutOfBoundsTestSimplePasses()
    {

        var player = new GameObject();
        var enemy = new GameObject();

        player.AddComponent<Player>();
        enemy.AddComponent<Enemy>();


        //Enemy position cannot equal player position if they are in seperate rooms, if this test passes then the enemy is so fast that it passes through its room to get to the player
        
        Assert.AreEqual(enemy.transform.position.x, player.transform.position.x);

    }


}
