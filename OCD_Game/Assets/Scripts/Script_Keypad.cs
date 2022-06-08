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

    private void Start()
    {
        InitialScreenColor = Screen.material.color;
    }
    public void Interact()
    {
        if (bCanInteract)
        {
            if (Door != null)
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
            else if (DisinfectPromp != null)
            {
                DisinfectPromp.Interact();
                StartCoroutine(Accepted());
            }
        }
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
