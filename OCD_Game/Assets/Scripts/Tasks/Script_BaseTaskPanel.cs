using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_BaseTaskPanel : MonoBehaviour
{
    #region Private
    protected Script_Player Player;
    protected Script_TaskPanel TaskList;
    protected string Name;
    protected Script_Alarm Alarm;

    protected void Start()
    {
        Player = FindObjectOfType<Script_Player>();
        TaskList = FindObjectOfType<Script_TaskPanel>();
        Alarm = FindObjectOfType<Script_Alarm>();
    }
    #endregion

    #region Public
    public void SetName(string _name)
    {
        Name = _name;
    }
    public void CloseTask(bool _satisfying)
    {
        Player.SetInteracting(false);
        if (_satisfying)
        {
            if (TaskList.IsTaskOnTop(Name))
                Alarm.ResetVolume();
            TaskList.CompleteTask(Name);
        }
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    #endregion
}
