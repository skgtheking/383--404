using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyTest
{
    private Enemy enemy;

    [SetUp]
    public void SetUp()
    {
        var enemyGO = new GameObject();
        enemy = enemyGO.AddComponent<Enemy>();

        enemy.movespeed = 5f; // Initial speed for testing
    enemy.viewdistance = 10f; // Initial view distance for testing
       enemy.increase = 1f; // Speed increase amount for testing
    }

    [UnityTest]
    public IEnumerator EnemySpeedIncrease()
    {
        var playerGO = new GameObject();
        playerGO.tag = "player";
        var player = playerGO.AddComponent<Player>();

    // Assign the mock player GameObject to the Enemy script
        enemy.player = playerGO;

    // Start the enemy speed increase method
        enemy.increaseEnemySpeed();


        yield return new WaitForSeconds(6); // Wait for 5 seconds (initial delay + 1 extra second)

    // Check if the enemy's speed has increased
        Assert.AreEqual(7f, enemy.movespeed);
    }


    [UnityTest]
    public IEnumerator EnemyWallGlitch()
    {
        var playerGO = new GameObject();
        var player = playerGO.AddComponent<Player>();
        
        Vector2 initialPos = enemy.transform.position;

        enemy.player = playerGO;
        enemy.viewdistance = 100f;
        enemy.movespeed = 100f;

        yield return new WaitForSeconds(2);

        Vector2 latterPos = enemy.transform.position;

        if(initialPos == latterPos)
        {
            Debug.Log("Enemy passed through walls");
        }
        Assert.AreEqual(initialPos, latterPos);
    }

}
