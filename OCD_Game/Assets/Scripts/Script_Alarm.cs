using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Alarm : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] float volumeIncreasePerSecond;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (audioSource != null)
        {
            if (audioSource.volume <= 1)
            {
                audioSource.volume += Time.deltaTime * volumeIncreasePerSecond;
            }
        }
    }
    public void ResetVolume()
    {
        audioSource.volume = 0;
    }
}
