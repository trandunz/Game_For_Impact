using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Keypad : MonoBehaviour
{
    [SerializeField] Script_Door Door;
    [SerializeField] Script_DisInfectPrompt DisinfectPromp;
    [SerializeField] MeshRenderer Screen;
    Color InitialScreenColor;
    bool bCanInteract = true;
    bool doorCoroutineIsRunning = false;

    private void Start()
    {
        InitialScreenColor = Screen.material.color;
    }
    public bool IsDisinfectionInProcess()
    {
        if (DisinfectPromp == null)
        {
            return false;
        }

        return DisinfectPromp.IsInteracting();
    }
    public void Interact()
    {
        if (bCanInteract)
        {
            if (DisinfectPromp != null)
            {
                if (!DisinfectPromp.bDisinfecting())
                {
                    DisinfectPromp.Interact();
                }
            }
            if (Door != null)
            {
                if (DisinfectPromp != null)
                {
                    if (DisinfectPromp.bDisinfecting())
                    {
                        if (DisinfectPromp.bDisinfecting() == true || DisinfectPromp.IsInteracting() == true)
                        {
                            StartCoroutine(Decline());
                        }
                        else
                        { 
                            StartCoroutine(DisinfectRoutine());
                        }
                    }
                    else
                    {
                        StartCoroutine(NoDisinfectionRoutine());
                    }
                }
                else
                {
                    if (Door.bLocked() == false)
                    {
                        StartCoroutine(Accepted());
                        Door.OpenDoor();
                    }
                    else
                    {
                        StartCoroutine(Decline());
                    }
                }
            }
        }
    }
    IEnumerator DisinfectRoutine()
    {
        if (DisinfectPromp != null)
        {
            if (!doorCoroutineIsRunning)
            {
                doorCoroutineIsRunning = true;
                yield return new WaitUntil(() => (DisinfectPromp.bDisinfecting() == false && DisinfectPromp.IsInteracting() == false));
                StartCoroutine(Accepted());
                Door.OpenDoor();
                doorCoroutineIsRunning = false;
            }
        }
        else
            yield return null;
        
    }
    IEnumerator NoDisinfectionRoutine()
    {
        if (DisinfectPromp != null)
        {
            if (!doorCoroutineIsRunning)
            {
                doorCoroutineIsRunning = true;
                yield return new WaitUntil(() => (DisinfectPromp.IsInteracting() == false));
                StartCoroutine(Accepted());
                Door.OpenDoor();
                doorCoroutineIsRunning = false;
            }
        }
        else
            yield return null;
    }
    IEnumerator Accepted()
    {
        bCanInteract = false;
        Screen.material.color = Color.green;
        yield return new WaitForSeconds(1);
        Screen.material.color = InitialScreenColor;
        bCanInteract = true;
    }
    IEnumerator Decline()
    {
        bCanInteract = false;
        Screen.material.color = Color.red;
        yield return new WaitForSeconds(1);
        Screen.material.color = InitialScreenColor;
        bCanInteract = true;
    }
}
