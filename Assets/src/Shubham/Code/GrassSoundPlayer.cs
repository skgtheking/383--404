using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSoundPlayer : SoundPlayer
{
    public override void PlaySound()
    {
        AudioManager.Instance.PlayWalkingGrassSound();
        Debug.Log("Playing grass sound");
    }
}