using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_TaskInteractable : MonoBehaviour
{
    #region Private
    [SerializeField] GameObject UIPanel;
    #endregion

    #region Public
    public void Interact()
    {
        UIPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    #endregion
}
