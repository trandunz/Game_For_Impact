using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Door : MonoBehaviour
{
    GameObject Right, Left;
    GameObject Player;
    Animator DoorAnimation;
    [SerializeField] bool IsLocked = false;

    private void Start()
    {
        DoorAnimation = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player" && !IsLocked)
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player" && !IsLocked)
        {
            CloseDoor();
        }
    }
    public void CloseDoor()
    {
        DoorAnimation.SetBool("Open", false);
    }
    public void OpenDoor()
    {
        DoorAnimation.SetBool("Open", true);
    }
    public IEnumerator Lock(float _seconds)
    {
        if (!IsLocked)
        {
            IsLocked = true;
            yield return new WaitForSeconds(_seconds);
            IsLocked = false;
        }
        else
            yield return null;
    }
}
