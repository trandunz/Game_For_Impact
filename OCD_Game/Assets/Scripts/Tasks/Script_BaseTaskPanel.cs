﻿using System.Collections;
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
    Animator animator;

    protected void Start()
    {
        Player = FindObjectOfType<Script_Player>();
        TaskList = FindObjectOfType<Script_TaskPanel>();
        Alarm = FindObjectOfType<Script_Alarm>();
        
    }

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }
    #endregion

    #region Public
    public void SetName(string _name)
    {
        Name = _name;
    }
    public void OpenTask()
    {
        if (animator)
        {
            while (animator.GetBool("Open") == false)
            {
                animator.SetBool("Open", true);
            }
        }
    }
    public void CloseTask(bool _satisfying)
    {
        if (animator)
        {
            while (animator.GetBool("Open") == true)
            {
                animator.SetBool("Open", false);
            }
        }
        StartCoroutine(closeRoutine(_satisfying));
    }
    IEnumerator closeRoutine(bool _satisfying)
    {
        yield return new WaitForSeconds(3.0f);
        Player.SetInteracting(false);
        if (_satisfying)
        {
            if (TaskList.IsTaskOnTop(Name))
                Alarm.ResetVolume();
            TaskList.CompleteTask(Name);
        }
        gameObject.SetActive(false);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    bool AnimatorIsPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }

    #endregion
}
