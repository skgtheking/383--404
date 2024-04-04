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
        Enemy enemyScript = GameObject.FindWithTag("enemy").GetComponent<Enemy>();
        GameObject player = new GameObject();
        GameObject enemy = new GameObject();

        player.AddComponent<Player>();
        enemy.AddComponent<Enemy>();

        enemyScript.speedTest();

        //Enemy position cannot equal player position if they are in seperate rooms, if this test passes then the enemy is so fast that it passes through its room to get to the player
        
        Assert.AreEqual(enemy.transform.position, player.transform.position);

    }


}
