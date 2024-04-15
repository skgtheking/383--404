using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Design Pattern: Factory

public abstract class Trap : MonoBehaviour
{

    public abstract void Spawn();

    public virtual void Activate()
    {
        Debug.Log("Generic trap activated!");
    }


    // Example method to find the player GameObject
}

public class FireTrap : Trap
{
    public override void Spawn()
    {
        Debug.Log("Fire Trap spawned!");
    }
}

public class StoneTrap : Trap
{
    public override void Spawn()
    {
        Debug.Log("Stone Trap spawned!");
    }

    public override void Activate()
    {
        Debug.Log("Stone Trap activated!");
    }
}
public class TrapHandler
{
    public static GameObject LoadTrapPrefab(string trapname)
    {
        switch (trapname)
        {
            case "Fire":
                return Resources.Load<GameObject>("FireTrapPrefab");
            case "Stone":
                return Resources.Load<GameObject>("StoneTrapPrefab");
            case "Fly":
                return Resources.Load<GameObject>("FlyTrapPrefab");
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
        Debug.Log("Trap prefab loaded successfully: " + trapPrefab.name);
        GameObject trapInstance = GameObject.Instantiate(trapPrefab, position, Quaternion.identity);
        Trap trapComponent = trapInstance.GetComponent<Trap>();
        trapComponent.Spawn();
        Debug.Log("Trap spawned and activated successfully: " + trapname);
            
        
    }
    else
    {
        Debug.LogError("Failed to load trap prefab: " + trapname);
    }
}
}
