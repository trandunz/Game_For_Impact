using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Rotate : MonoBehaviour
{
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

        PointLight1.range = Alarm.fVolume * 50;
    }
}
