using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_GameOver : MonoBehaviour
{
    Script_TaskPanel taskPanel;
    [SerializeField]Text OCDTasks;
    [SerializeField] Text NormalTasks;
    Script_DialoguePopup dialoguePopup;
    void Start()
    {
        taskPanel = FindObjectOfType<Script_TaskPanel>();
        dialoguePopup = FindObjectOfType<Script_DialoguePopup>();
    }

    private void OnEnable()
    {
        dialoguePopup = FindObjectOfType<Script_DialoguePopup>();
        dialoguePopup.DialoguePopup(6, "Everything Alright Up There? We Havent Heard From You Since This Morning!", false);
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
