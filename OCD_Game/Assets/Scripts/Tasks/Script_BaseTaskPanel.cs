using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_BaseTaskPanel : MonoBehaviour
{
    #region Private
    protected Script_Player Player;
    protected Script_TaskPanel TaskList;
    protected bool Completed;
    protected void Start()
    {
        Player = FindObjectOfType<Script_Player>();
        TaskList = FindObjectOfType<Script_TaskPanel>();
    }
    #endregion

    #region Public
    public void CloseTask(bool _satisfying)
    {
        if (!Completed)
        {
            Player.SetInteracting(false);
            if (_satisfying)
                TaskList.CompleteTask();
        }
        Completed = true;
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    #endregion
}
