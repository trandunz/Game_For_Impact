using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_BaseTaskPanel : MonoBehaviour
{
    #region Private
    Script_Player Player;
    private void Start()
    {
        Player = FindObjectOfType<Script_Player>();
    }
    #endregion

    #region Public
    public void CloseTask()
    {
        Player.SetInteracting(false);
    }
    #endregion
}
