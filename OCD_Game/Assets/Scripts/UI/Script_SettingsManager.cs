using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_SettingsManager : MonoBehaviour
{
    public static float AudioVolume;
    public static float MouseSensitivity;

    [SerializeField] float PanStereo;

    [SerializeField] Slider AudioSlider;
    [SerializeField] Text AudioNumber;

    [SerializeField] Slider SensitivitySlider;

    [SerializeField] Slider StereoPanSlider;

    // Start is called before the first frame update
    void Start()
    {
        LoadPrefs();
        AudioSlider.value = AudioVolume * 10;
        int i = (int)AudioSlider.value;
        AudioNumber.text = i.ToString();
        AudioListener.volume = AudioVolume;

        StereoPanSlider.value = PanStereo;
        UpdatePan();

        SensitivitySlider.value = MouseSensitivity;
        Script_FirstPersonMotor Player = FindObjectOfType<Script_FirstPersonMotor>();
        if (Player != null)
        {
            Player.UpdateSensitivity();
        }
    }

    public void UpdateAudio()
    {
        float fSliderNumber = AudioSlider.value / 10;
        int iSliderNumber = (int)AudioSlider.value;
        AudioNumber.text = iSliderNumber.ToString();
        AudioVolume = fSliderNumber;
        AudioListener.volume = AudioVolume;
        SavePrefs();
    }

    public void UpdatePan()
    {
        float fSliderValue = (StereoPanSlider.value - 5) / 10;
        PanStereo = StereoPanSlider.value;
        foreach (AudioSource source in FindObjectsOfType<AudioSource>())
        {
            source.panStereo = fSliderValue;
        }
        SavePrefs();
    }

    public void UpdateSensitivty()
    {
        MouseSensitivity = SensitivitySlider.value;
        if (MouseSensitivity <= 0)
        {
            MouseSensitivity = 0.1f;
        }
        Script_FirstPersonMotor Player = FindObjectOfType<Script_FirstPersonMotor>();
        if (Player != null)
        {
            Player.UpdateSensitivity();
        }
        SavePrefs();
    }

    void SavePrefs()
    {
        PlayerPrefs.SetFloat("Volume", AudioVolume);
        PlayerPrefs.SetFloat("Sensitivity", MouseSensitivity);
        PlayerPrefs.SetFloat("PanStereo", PanStereo);
        PlayerPrefs.Save();
    }

    void LoadPrefs()
    {
        AudioVolume = PlayerPrefs.GetFloat("Volume", 1.0f);
        MouseSensitivity = PlayerPrefs.GetFloat("Sensitivity", 1.0f);
        PanStereo = PlayerPrefs.GetFloat("PanStereo", 5.0f);
    }
}
