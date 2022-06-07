using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_DialoguePopup : MonoBehaviour
{
    [SerializeField] Text messageText;
    [SerializeField] AudioClip voiceClip;
    AudioSource voiceSource;
    Animator animator;
    bool isTalking = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        voiceSource = GetComponent<AudioSource>();
        DialoguePopup(3, 
            "Alright Captain. " +
            "Over and out.");
    }
    public void DialoguePopup(int _showTime, string _message)
    {
        StartCoroutine(PopupMessage(_showTime, _message));
    }
    IEnumerator PopupMessage(int _showTime, string _message)
    {
        if (!isTalking)
        {
            isTalking = true;
            messageText.text = _message;
            animator.SetBool("Open", true);
            StartCoroutine(PlayVoiceClip());
            yield return new WaitForSeconds(_showTime);
            animator.SetBool("Open", false);
            isTalking = false;
        }
        else
        {
            yield return null;
        }
    }
    IEnumerator PlayVoiceClip()
    {
        yield return new WaitForSeconds(1);
        voiceSource.PlayOneShot(voiceClip);
    }
}
