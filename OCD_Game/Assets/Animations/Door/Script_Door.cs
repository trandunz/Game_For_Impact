using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Door : MonoBehaviour
{
    GameObject Right, Left;
    GameObject Player;
    Animator DoorAnimation;
    bool IsOpen = false;

    [SerializeField] bool IsLocked = false;
    [SerializeField] AudioClip Audio_DoorOpened;
    [SerializeField] AudioClip Audio_DoorClosed;
    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        DoorAnimation = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player" && !IsLocked && IsOpen)
        {
            CloseDoor();
        }
    }
    public void CloseDoor()
    {
        IsOpen = false;
        DoorAnimation.SetBool("Open", false);
        audioSource.PlayOneShot(Audio_DoorClosed);
    }
    public void OpenDoor()
    {
        IsOpen = true;
        audioSource.PlayOneShot(Audio_DoorOpened);
        DoorAnimation.SetBool("Open", true);

        StartCoroutine(CloseAfterOpen(3));
    }

    public bool bLocked()
    {
        return IsLocked;
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
    IEnumerator CloseAfterOpen(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        if (IsOpen)
        {
            CloseDoor();
        }
        else
        {
            yield return null;
        }
    }
}
