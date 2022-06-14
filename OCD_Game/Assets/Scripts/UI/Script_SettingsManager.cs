using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_SettingsManager : MonoBehaviour
{
    public static float AudioVolume;
    public static float MouseSensitivity;
    public static Vector2 ScreenSize;

    [SerializeField] Slider AudioSlider;
    [SerializeField] Text AudioNumber;

    [SerializeField] Slider SensitivitySlider;

    [SerializeField] Slider StereoPanSlider;

    // Start is called before the first frame update
    void Start()
    {
        // load from settings file
    }

    public void UpdateAudio()
    {
        float fSliderNumber = AudioSlider.value / 10;
        int iSliderNumber = (int)AudioSlider.value;
        AudioNumber.text = iSliderNumber.ToString();
        AudioVolume = fSliderNumber;
        AudioListener.volume = AudioVolume;
    }

    public void UpdatePan()
    {
        float sliderNumber = (StereoPanSlider.value - 5) / 10;
        

        foreach (AudioSource source in FindObjectsOfType<AudioSource>())
        {
            source.panStereo = sliderNumber;
        }
    }

    public void UpdateSensitivty()
    {
        MouseSensitivity = SensitivitySlider.value;
        if (MouseSensitivity <= 0)
        {
            MouseSensitivity = 1;
        }
        Script_FirstPersonMotor Player = FindObjectOfType<Script_FirstPersonMotor>();
        if (Player != null)
        {
            Player.UpdateSensitivity();
        }
    }
}
