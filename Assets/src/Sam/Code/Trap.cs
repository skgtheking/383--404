using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Design Pattern: Factory

public abstract class Trap : MonoBehaviour
{
    public abstract void Spawn();

    // Virtual method to demonstrate explicit dynamic binding
    public virtual void Activate()
    {
        Debug.Log("Generic trap activated!");
    }
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

    // Override the Activate method to provide specific behavior for StoneTrap
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
            Trap trapComponent = trapInstance.GetComponent<Trap>();
            trapComponent.Spawn();
            // Explicit dynamic binding: Call the Activate method of the specific trap type
            trapComponent.Activate();
        }
    }
}
