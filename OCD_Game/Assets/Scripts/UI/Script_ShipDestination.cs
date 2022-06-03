using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_ShipDestination : MonoBehaviour
{
    Slider slider;
    [SerializeField] float TimeToDestination;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value += Time.deltaTime / TimeToDestination;
    }

    public float GetProgress()
    {
        return slider.value;
    }
}
