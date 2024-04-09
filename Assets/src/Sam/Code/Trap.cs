using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Design Pattern: Factory

//Dynamic Binding isn't explicitly demonstrated but it is indirectly achieved. 
//When calling the spawn() method on an instance of Trap, the appropriate implementation of spawn() from the subclass (FireTrap or StoneTrap) is dynamically bound and executed based on the actual type of the object at runtime
public abstract class Trap : MonoBehaviour
{
    public abstract void spawn();
}

public class FireTrap : Trap
{
    public override void spawn()
    {
        Debug.Log("Fire Trap spawned! ");
    }

}

public class StoneTrap : Trap
{
    public override void spawn()
    {
        Debug.Log("Stone Trap spawned!");
    }
}

public class TrapHandler
{
    public static GameObject LoadTrapPrefab(string trapname)
    {
        switch(trapname)
        {
            case "Fire":
                return Resources.Load<GameObject>("FireTrapPrefab");
            case "Stone":
                return Resources.Load<GameObject>("StoneTrapPrefab");
            default:
                Debug.LogError("Unknown Trap: " + trapname);
                return null;
        }
    }

    public static void SpawnTrap(string trapname, Vector2 position)
    {
        GameObject trapPrefab = LoadTrapPrefab(trapname);
        if (trapPrefab != null)
        {
            GameObject trapInstance = GameObject.Instantiate(trapPrefab, position, Quaternion.identity);
            trapInstance.GetComponent<Trap>().spawn();
        }
    }
}
