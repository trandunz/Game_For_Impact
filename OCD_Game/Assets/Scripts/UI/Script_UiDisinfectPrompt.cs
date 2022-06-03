using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_UiDisinfectPrompt : MonoBehaviour
{
    Script_DisInfectPrompt promptTrigger;
    Script_Alarm Alarm;
    private void Start()
    {
        Alarm = FindObjectOfType<Script_Alarm>();
    }
    public void SetPromptTrigger(Script_DisInfectPrompt _promptTrigger)
    {
        promptTrigger = _promptTrigger;
    }
    public void FinishInteraction(bool _satisfied)
    {
        FindObjectOfType<Script_Player>()?.SetInteracting(false);
        if (_satisfied)
            Alarm?.ResetVolume();
    }
    public void LockDoors(float _time)
    {
        promptTrigger?.LockDoors(_time);
    }
}
