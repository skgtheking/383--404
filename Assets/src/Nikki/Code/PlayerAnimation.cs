using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator PlayerAnimator;

    public string currentState;
    public string PlayerIdle = "PlayerIdle";
    public string PlayerWalk = "PlayerWalk";

    
    void Start()
    {
        PlayerAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (PlayerVariable.IsWalking) 
        {
            PlayAnimation(PlayerWalk);
        }
        else
        {
            PlayAnimation(PlayerIdle);
        }
    }

    public void PlayAnimation(string newState) 
    {
        if (currentState == newState) return;
        PlayerAnimator.Play(newState);
        currentState = newState;
    }
}
