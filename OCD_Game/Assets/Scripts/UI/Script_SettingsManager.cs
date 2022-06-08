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

    // Start is called before the first frame update
    void Start()
    {
        // load from settings file
    }

    public void UpdateAudio()
    {
        float fSliderNumber = AudioSlider.value * 10;
        int iSliderNumber = (int)fSliderNumber;
        AudioNumber.text = iSliderNumber.ToString();
        AudioVolume = AudioSlider.value;
    }

    public void UpdateSensitivty()
    {
        MouseSensitivity = (int)SensitivitySlider.value;
    }
}
