// Description: Rotates the parent object of the light, rotating the light in a circle
//
// made by: Josh

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Rotate : MonoBehaviour
{
    // variables
    [SerializeField] float fRotateSpeed;
    [SerializeField] Light PointLight1;
    [SerializeField] Script_Alarm Alarm;

    // Start is called before the first frame update
    void Start()
    {
        Alarm = FindObjectOfType<Script_Alarm>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, fRotateSpeed * Time.deltaTime, 0);

        // makes the point light range based on the volume of the alarm sound, making the light more
        // intense as the alarm gets more intense
        PointLight1.range = Alarm.fVolume * 50;
    }
}
