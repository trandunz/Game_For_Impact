// Description: Moves the attatched object on a sine wave
//
// made by: Josh

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scipt_SineWave : MonoBehaviour
{
    [SerializeField] float m_magnitude = 1.0f;
    [SerializeField] float m_period = 1.0f;
    public float m_degrees;

    Vector2 StartPos;

    private void Start()
    {
        StartPos = transform.position;
    }

    private void Update()
    {
        // calculate the new angle
        float degreesPerSecond = 360.0f / m_period;
        m_degrees = Mathf.Repeat(m_degrees + (Time.deltaTime * degreesPerSecond), 360.0f);
        float radians = m_degrees * Mathf.Deg2Rad;

        // get the offset from the calculated angle, then update the position
        Vector2 offset = new Vector2(0.0f, m_magnitude * Mathf.Sin(radians));
        transform.position = StartPos + offset;
    }
}
