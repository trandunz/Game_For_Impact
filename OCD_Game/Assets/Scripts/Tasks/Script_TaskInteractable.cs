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
        TaskPanel = Instantiate(TaskPanel, GameObject.FindWithTag("MainCanvas").transform);
        TaskPanel.GetComponent<Script_BaseTaskPanel>().SetName(TaskName);
    }
    private void Awake()
    {
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
        TaskPanel.GetComponent<Script_BaseTaskPanel>().OpenTask();
        Cursor.lockState = CursorLockMode.None;
    }
    #endregion
}
