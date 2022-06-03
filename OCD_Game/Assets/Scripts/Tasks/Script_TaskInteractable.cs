using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_TaskInteractable : MonoBehaviour
{
    #region Private
    [SerializeField] GameObject TaskPanel;
    [SerializeField] string TaskName;
    private void Start()
    {
        TaskPanel = Instantiate(TaskPanel, GameObject.FindObjectOfType<Canvas>().transform);
        TaskPanel.SetActive(false);
    }
    #endregion

    #region Public
    public string GetName()
    {
        return TaskName;
    }
    public void Interact()
    {
        TaskPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    #endregion
}
