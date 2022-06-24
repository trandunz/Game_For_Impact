using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_LoadSettingInit : MonoBehaviour
{
    [SerializeField] float PanStereo;

    // Start is called before the first frame update
    void Start()
    {
        LoadPrefs();

        AudioListener.volume = Script_SettingsManager.AudioVolume;

        UpdatePan();

        Script_FirstPersonMotor Player = FindObjectOfType<Script_FirstPersonMotor>();
        if (Player != null)
        {
            Player.UpdateSensitivity();
        }

        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePan()
    {
        float fSliderValue = (PanStereo - 5) / 10;
        foreach (AudioSource source in FindObjectsOfType<AudioSource>())
        {
            source.panStereo = fSliderValue;
        }
    }


    void LoadPrefs()
    {
        Script_SettingsManager.AudioVolume = PlayerPrefs.GetFloat("Volume", 1.0f);
        Script_SettingsManager.MouseSensitivity = PlayerPrefs.GetFloat("Sensitivity", 1.0f);
        PanStereo = PlayerPrefs.GetFloat("PanStereo", 5.0f);
    }
}
