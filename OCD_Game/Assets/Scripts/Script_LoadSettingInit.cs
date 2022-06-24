// Description: Loads the stored settings, then deletes the object
//
// made by: Josh

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_LoadSettingInit : MonoBehaviour
{
    [SerializeField] float PanStereo;

    // Start is called before the first frame update
    void Start()
    {
        // load the settings, then update the info
        LoadPrefs();

        AudioListener.volume = Script_SettingsManager.AudioVolume;

        UpdatePan();

        // update the sensitivity if a player character is in the scene
        Script_FirstPersonMotor Player = FindObjectOfType<Script_FirstPersonMotor>();
        if (Player != null)
        {
            Player.UpdateSensitivity();
        }

        Destroy(gameObject);
    }

    /// <summary>
    /// updates the audio pan based on the stored value that was found in the stored settings
    /// </summary>
    public void UpdatePan()
    {
        float fSliderValue = (PanStereo - 5) / 10;
        foreach (AudioSource source in FindObjectsOfType<AudioSource>())
        {
            source.panStereo = fSliderValue;
        }
    }

    /// <summary>
    /// loads the stored settings
    /// </summary>
    void LoadPrefs()
    {
        Script_SettingsManager.AudioVolume = PlayerPrefs.GetFloat("Volume", 1.0f);
        Script_SettingsManager.MouseSensitivity = PlayerPrefs.GetFloat("Sensitivity", 1.0f);
        PanStereo = PlayerPrefs.GetFloat("PanStereo", 5.0f);
    }
}
