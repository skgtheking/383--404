using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSoundPlayer : SoundPlayer
{
    public override void PlaySound()
    {
        AudioManager.Instance.PlayFireBurningSound();
        Debug.Log("Playing fire sound");
    }
}
