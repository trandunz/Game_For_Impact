using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ContaminationPrompt : MonoBehaviour
{
    [SerializeField] AudioSource Audio;
    bool IsWarningPlaying = false;
    Script_Rotate RedLight;

    private void Start()
    {
        RedLight = FindObjectOfType<Script_Rotate>();
    }

    // Update is called once per frame
    void Update()
    {
       if(GetComponentInParent<Script_DisInfectPrompt>().isDisinfecting == true)
        {
            RedLight.DisableLight();
            Audio.Stop();
            IsWarningPlaying = false;
            GetComponentInParent<Script_DisinfectRoomManager>().StopAllWarnings();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RedLight.EnableLight();
            Audio.Play();
            IsWarningPlaying = true;
        }
    }

    public void StopWarning()
    {
        if (Audio.isPlaying)
        {
            RedLight.DisableLight();
            Audio.Stop();
            IsWarningPlaying = false;
        }
    }
}
