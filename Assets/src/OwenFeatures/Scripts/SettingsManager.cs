using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsManager : SettingsMenu
{
    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public GameObject SettingsMenu2;
    Resolution[] resolutions;
    private bool settingsOn;

    public override void ChangedF()
    {

    }
    void Update()
    {
        invControl();
    }
    void Start()
    {
        settingsOn = false;

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    void invControl()
    {
        if (Input.GetKeyDown(KeyCode.G) && settingsOn)
        {
            Time.timeScale = 1;
            SettingsMenu2.SetActive(false);
            settingsOn = false;
        }

        else if (Input.GetKeyDown(KeyCode.G) && !settingsOn)
        {
            Time.timeScale = 0;
            SettingsMenu2.SetActive(true);
            settingsOn = true;
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        GameObject resol = new GameObject();
        SettingsMenu res = resol.AddComponent<Resolutions>();
        res.ChangedD();
   }


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        GameObject volum = new GameObject();
        SettingsMenu vol = volum.AddComponent<Volume>();
        vol.ChangedD();
        vol.ChangedF();
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        GameObject gr = new GameObject();
        SettingsMenu graph = gr.AddComponent<Graphics>();
        graph.ChangedD();
        graph.ChangedF();
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        GameObject full = new GameObject();
        SettingsMenu fs = full.AddComponent<FullScr>();
        fs.ChangedD();
        fs.ChangedF();
    }
}
