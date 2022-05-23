using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Door : MonoBehaviour
{
    GameObject Right, Left;
    GameObject Player;
    Animator DoorAnimation;

    private void Start()
    {
        DoorAnimation = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            DoorAnimation.SetBool("Open", true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            DoorAnimation.SetBool("Open", false);
        }
    }
}
