using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyTest
{
    
    [UnityTest]
    public IEnumerator speedChange()
    {

        var p = new GameObject();
        var e = new GameObject();
        
        var player = p.AddComponent<Player>();
        var enemy = p.AddComponent<Enemy>();

        enemy.speedTest();

        //Enemy position cannot equal player position if they are in seperate rooms, if this test passes then the enemy is so fast that it passes through its room to get to the player
        yield return new WaitForSeconds(1);

        Assert.AreEqual(enemy.transform.position.y, player.transform.position.y);
    }
}
