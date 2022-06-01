using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_UiDisinfectPrompt : MonoBehaviour
{
    Script_DisInfectPrompt promptTrigger;
    public void SetPromptTrigger(Script_DisInfectPrompt _promptTrigger)
    {
        promptTrigger = _promptTrigger;
    }
    public void LockDoors(float _time)
    {
        promptTrigger?.LockDoors(_time);
    }
}
