using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Script_TaskPanel : MonoBehaviour
{
    [SerializeField] Text CurrentTask;
    [SerializeField] Text OtherTasks;
    [SerializeField] List<string> tasks = new List<string>();
    [SerializeField] List<string> OCDTasks = new List<string>();

    float RandomTaskTimer = 0.0f;
    [SerializeField] float RandomTaskInterval = 5.0f;


    private void Start()
    {
    }
    private void Update()
    {
        if (RandomTaskTimer < RandomTaskInterval && !FindObjectOfType<Script_Player>().IsInteracting())
        {
            RandomTaskTimer += Time.deltaTime;
        }
        else if (RandomTaskTimer >= RandomTaskInterval)
        {
            RandomTaskTimer = 0.0f;
            AddOCDTask(OCDTasks[Random.Range(0, OCDTasks.Count)]);
        }

        OtherTasks.text = "";
        if (tasks.Count > 0)
        {
            CurrentTask.text = tasks[0];

            for(int i = 1; i < tasks.Count; i++)
            {
                OtherTasks.text += tasks[i] + "\n";
            }
        }
    }
    public string GetCurrentTask()
    {
        return tasks[0];
    }    
    public void AddOCDTask(string _task)
    {
        tasks.Insert(0,_task);
    }
    public void CompleteTask()
    {
        tasks.RemoveAt(0);
    }
}
