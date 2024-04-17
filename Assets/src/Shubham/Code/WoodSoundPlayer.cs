using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSoundPlayer : SoundPlayer
{
    public override void PlaySound(){
        AudioManager.Instance.PlayWalkingWoodSound();
        Debug.Log("Playing wood sound");
    }
}
