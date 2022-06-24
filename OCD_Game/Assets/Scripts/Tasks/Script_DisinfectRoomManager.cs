using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_DisinfectRoomManager : MonoBehaviour
{
    [SerializeField] Script_ContaminationPrompt[] ContaminationWarnings;

    public void Start()
    {
        ContaminationWarnings = FindObjectsOfType<Script_ContaminationPrompt>();
    }


    public void StopAllWarnings()
    {
        foreach (Script_ContaminationPrompt warning in ContaminationWarnings)
        {
            warning.StopWarning();
        }
    }
}
