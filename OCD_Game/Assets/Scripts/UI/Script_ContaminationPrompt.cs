using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ContaminationPrompt : MonoBehaviour
{
    [SerializeField] AudioSource Audio;
    bool IsWarningPlaying = false;
    
    // Update is called once per frame
    void Update()
    {
       if(GetComponentInParent<Script_DisInfectPrompt>().isDisinfecting == true)
        {
            Audio.Stop();
            IsWarningPlaying = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Audio.Play();
            IsWarningPlaying = true;
        }
    }
}
