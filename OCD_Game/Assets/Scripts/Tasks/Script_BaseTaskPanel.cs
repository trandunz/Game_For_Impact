using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_BaseTaskPanel : MonoBehaviour
{
    #region Private
    Script_Player Player;
    Script_ThreatLevel ThreatLevelMeter;
    private void Start()
    {
        Player = FindObjectOfType<Script_Player>();
        ThreatLevelMeter = FindObjectOfType<Script_ThreatLevel>();
    }
    #endregion

    #region Public
    public void CloseTask(bool _satisfying)
    {
        Player.SetInteracting(false);
        if (_satisfying)
            ThreatLevelMeter.DecreaseThreatLevel();
    }
    #endregion
}
