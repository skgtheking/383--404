using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTrap : Trap
{
    private GameObject player;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player");
        if (animator == null)
        {
            Debug.LogWarning("Animator component not assigned.");
        }
    }

    public override void Spawn()
    {
        Debug.Log("Fly Trap spawned!");
    }

    public override void Activate()
    {
        if (player != null && animator != null)
        {
            // Calculate the distance along the x-axis
            float distanceX = player.transform.position.x - transform.position.x;

            // If the player is on the left side of the trap
            if (distanceX < 0)
            {
                // Calculate the distance between the trap and the player
                float distance = Vector2.Distance(transform.position, player.transform.position);
                animator.SetFloat("distance", distance);
                displayDistance(distance);
            }
            else
            {
                // Player is not on the left side, deactivate the trap
                animator.SetFloat("distance", -1f); // Set distance to a negative value to deactivate
                Debug.Log("Player is not on the left side of the trap.");
            }
        }
        else
        {
            Debug.LogWarning("Player GameObject or Animator not found.");
        }
    }

    void Update()
    {
        Activate();
    }

    void displayDistance(float d)
    {
        Debug.Log(d);
    }
}
