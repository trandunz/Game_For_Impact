using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_GameOver : MonoBehaviour
{
    Script_TaskPanel taskPanel;
    [SerializeField]Text OCDTasks;
    [SerializeField] Text NormalTasks;
    void Start()
    {
        taskPanel = FindObjectOfType<Script_TaskPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        OCDTasks.text = "";
        NormalTasks.text = "";
        foreach (var task in taskPanel.GetCompletedOCDTasks())
        {
            OCDTasks.text += task + "\n";
        }
        foreach (var task in taskPanel.GetCompletedNormalTasks())
        {
            NormalTasks.text += task + "\n";
        }
    }
}
