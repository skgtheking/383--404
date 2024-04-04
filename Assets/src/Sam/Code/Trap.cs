using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Design Pattern: Factory
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
    public static Trap spawnTrap(string trapname)
    {
        switch(trapname)
        {
            case "Fire":
                return new FireTrap();
            case "Stone":
                return new StoneTrap();
            default:
                Debug.LogError("Unknown Trap: " + trapname);
                return null;
        }
    }
}
