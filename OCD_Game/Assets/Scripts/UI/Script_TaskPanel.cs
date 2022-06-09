using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Script_TaskPanel : MonoBehaviour
{
    [SerializeField] Text CurrentTask;
    [SerializeField] Text OtherTasks;
    [SerializeField] List<string> NormalTasks = new List<string>();
    [SerializeField] List<string> OCDTasks = new List<string>();
    List<string> Tasks = new List<string>();
    List<string> CompletedOCDTasks = new List<string>();
    List<string> CompletedNormalTasks = new List<string>();
    Script_DialoguePopup dialoguePopup;

    float RandomTaskTimer = 0.0f;
    [SerializeField] float RandomTaskInterval = 5.0f;


    private void Start()
    {
        foreach(string task in NormalTasks)
        {
            Tasks.Add(task);
        }
        dialoguePopup = FindObjectOfType<Script_DialoguePopup>();
    }
    private void Update()
    {
        OtherTasks.text = "";
        if (Tasks.Count < 2)
        {
            AddOCDTask(false);
        }
        if (Tasks.Count > 0)
        {
            CurrentTask.text = Tasks[0];
            OtherTasks.text = Tasks[1];
        }
    }
    public string GetCurrentTask()
    {
        return Tasks[0];
    }
    public bool HasTask(string _task)
    {
        if(_task == CurrentTask.text)
        {
            return true;
        }
        return false;
    }
    public void AddOCDTask(bool _atStart)
    {
        string task = Tasks[0];
        while (task == Tasks[0])
        {
            task = OCDTasks[Random.Range(0, OCDTasks.Count)];
        }
        
        if (_atStart)
        {
            dialoguePopup.DialoguePopup(3, task);
            Tasks.Insert(0, task);
        }   
        else
        {
            Tasks.Insert(Tasks.Count, task);
        }
    }
    public void CompleteTask(string _task)
    {
        if (CurrentTask.text == _task)
        {
            Tasks.RemoveAt(0);
            foreach (string ocdTask in OCDTasks)
            {
                if (ocdTask == _task)
                {
                    CompletedOCDTasks.Add(ocdTask);
                    break;
                }
            }
            foreach (string normalTask in NormalTasks)
            {
                if (normalTask == _task)
                {
                    CompletedNormalTasks.Add(normalTask);
                    StartCoroutine(AddDelayedOCDTask(1));
                    break;
                }
            }
            return;
        }
    }
    public bool IsTaskOnTop(string _task)
    {
        return _task == CurrentTask.text;
    }
    public string[] GetCompletedOCDTasks()
    {
        return CompletedOCDTasks.ToArray();
    }
    public string[] GetCompletedNormalTasks()
    {
        return CompletedNormalTasks.ToArray();
    }
    IEnumerator AddDelayedOCDTask(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        AddOCDTask(true);
    }
}
