using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public abstract class SettingsMenu : MonoBehaviour
{
    public abstract void ChangedF();

    public virtual void ChangedD()
    {
        Debug.Log("Lol");
    }
}
public class Volume : SettingsMenu
{
    public override void ChangedF()
    {
        Debug.Log("Volume Changed Factory");
    }

    public override void ChangedD()
    {
        Debug.Log("Volume Changed Dynamic");
    }
}   

public class Resolutions : SettingsMenu
{
    public override void ChangedF()
    {
        Debug.Log("Resolution Changed Factory");
    }

    public override void ChangedD()
    {
        Debug.Log("Resolution Changed Dynamic");
    }
}

public class Graphics : SettingsMenu
{
    public override void ChangedF()
    {
        Debug.Log("Graphics Changed Factory");
    }

    public override void ChangedD()
    {
        Debug.Log("Graphics Changed Dynamic");
    }
}

public class FullScr : SettingsMenu
{
    public override void ChangedF()
    {
        Debug.Log("FullScreen Changed Factory");
    }

    public override void ChangedD()
    {
        Debug.Log("FullScreen Changed Dynamic");
    }
}

public class SettingsM
{
    public static GameObject LoadSettings(string settingName)
    {
        return GameObject.FindWithTag(settingName);
    }

    public static void ChangeSetting(string settingName)
    {
        GameObject settingType = LoadSettings(settingName);

        if (settingType != null)
        {
            GameObject settingInstance = settingType;
            SettingsMenu settingComponent = settingInstance.GetComponent<SettingsMenu>();
            settingComponent.ChangedF();
        }
    }
}