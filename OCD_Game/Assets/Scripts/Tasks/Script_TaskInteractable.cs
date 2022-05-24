using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_TaskInteractable : MonoBehaviour
{
    #region Private
    [SerializeField] GameObject TaskPanel;
    private void Start()
    {
        TaskPanel = Instantiate(TaskPanel, GameObject.FindObjectOfType<Canvas>().transform);
        TaskPanel.SetActive(false);
    }
    #endregion

    #region Public
    public void Interact()
    {
        TaskPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    #endregion
}
