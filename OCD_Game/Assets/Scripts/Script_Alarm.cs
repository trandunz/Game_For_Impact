using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Alarm : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioSource TaskCompleteAudioSource;
    [SerializeField] AudioClip taskComplete;
    [SerializeField] float volumeIncreasePerSecond;
    public float fVolume;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (audioSource != null)
        {
            if (audioSource.volume < 1)
            {
                audioSource.volume += Time.deltaTime * volumeIncreasePerSecond;
                fVolume = audioSource.volume;

                if (audioSource.volume > 1)
                {
                    audioSource.volume = 1;
                }
            }
        }
    }
    public void ResetVolume()
    {
        audioSource.volume = 0;
        TaskCompleteAudioSource.PlayOneShot(taskComplete);
    }
}
