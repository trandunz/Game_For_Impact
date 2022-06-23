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
    Script_OpeningEyes FadingScreenUI;
    Animator animator;

    protected void Start()
    {
        Player = FindObjectOfType<Script_Player>();
        TaskList = FindObjectOfType<Script_TaskPanel>();
        Alarm = FindObjectOfType<Script_Alarm>();
        FadingScreenUI = FindObjectOfType<Script_OpeningEyes>();
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
            animator.SetBool("Open", true);
        }
    }
    public void CloseTask(bool _satisfying)
    {
        if (animator)
        {
            animator.SetBool("Open", false);
        }
        StartCoroutine(closeRoutine(_satisfying));
    }
    IEnumerator closeRoutine(bool _satisfying)
    {
        yield return new WaitUntil(() => !AnimatorIsPlaying() && animator.GetCurrentAnimatorStateInfo(0).IsName("TaskPanel_Close"));
        Player.SetInteracting(false);
        if (_satisfying)
        {
            if (TaskList.IsTaskOnTop(Name))
                Alarm.ResetVolume();
            TaskList.CompleteTask(Name);
        }
        animator.CrossFade("New State", 0f);

        animator.Update(0f);

        animator.Update(0f);
        gameObject.SetActive(false);
    }
    public void ReturnToMainMenu()
    {
        StartCoroutine(ReturnToMainMenuRoutine());
    }

    IEnumerator ReturnToMainMenuRoutine()
    {
        if (FadingScreenUI.IsScreenFading() == false)
        {
            FadingScreenUI.CloseEyes();
            yield return new WaitUntil(() => FadingScreenUI.IsScreenFading() == false);
            SceneManager.LoadScene(0);
        }
    }

    bool AnimatorIsPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }

    #endregion
}
