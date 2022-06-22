using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_DialoguePopup : MonoBehaviour
{
    [SerializeField] Text messageText;
    [SerializeField] AudioClip voiceClip;
    [SerializeField] Sprite OCDIntercom;
    [SerializeField] Sprite MCIntercom;
    Image basePanelImage;
    AudioSource voiceSource;
    Animator animator;
    bool isTalking = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        voiceSource = GetComponent<AudioSource>();
        basePanelImage = GetComponent<Image>();
        DialoguePopup(6, "Ride And Shine Sleepyhead. Time to keep this ship alive another day. Over And Out", false);
    }
    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        voiceSource = GetComponent<AudioSource>();
        basePanelImage = GetComponent<Image>();
        DialoguePopup(6, "Ride And Shine Sleepyhead. Time to keep this ship alive another day. Over And Out", false);
    }
    public void DialoguePopup(int _showTime, string _message, bool _ocd =  true)
    {
        StartCoroutine(PopupMessage(_showTime, _message, _ocd));
    }
    IEnumerator PopupMessage(int _showTime, string _message, bool _ocd)
    {
        if (!isTalking)
        {
            if (_ocd)
            {
                basePanelImage.sprite = MCIntercom;
            }
            else
            {
                basePanelImage.sprite = MCIntercom;
            }
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
