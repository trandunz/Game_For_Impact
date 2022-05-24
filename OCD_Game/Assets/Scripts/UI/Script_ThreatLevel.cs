using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_ThreatLevel : MonoBehaviour
{
    #region Private
    Slider ThreatSlider;
    float ThrealLevel;
    [SerializeField] float ThreatSpeed;
    float ThreatPauseTimer = 0.0f;
    [SerializeField] float ThreatPauseTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        ThreatSlider = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ThreatPauseTimer > 0)
        {
            ThreatPauseTimer -= Time.deltaTime;
        }
        else
        {
            ThrealLevel += Time.deltaTime * ThreatSpeed;
        }
        ThreatSlider.value = ThrealLevel;
    }
    #endregion

    #region Public
    public void DecreaseThreatLevel(float _value)
    {
        ThrealLevel -= _value;
        ThreatPauseTimer = ThreatPauseTime;
        if (ThrealLevel <= 0)
        {
            ThrealLevel = 0;
        }
    }
    #endregion
}
