﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_DisInfectPrompt : MonoBehaviour
{
    #region Private
    [SerializeField] GameObject Prompt;
    [SerializeField] Script_Door[] Doors;
    Script_Player PlayerScript;
    bool isDisinfecting = false;
    bool isInteracting = false;
    [SerializeField]float disInfectTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        PlayerScript = FindObjectOfType<Script_Player>();
        GameObject spawnedPrompt = GameObject.FindWithTag("DisInfectPrompt");
        if (spawnedPrompt)
        {
            Prompt = spawnedPrompt;
        }
        else
        {
            Prompt = Instantiate(Prompt, GameObject.FindObjectOfType<Canvas>().transform);
        }
        Prompt.GetComponent<Script_UiDisinfectPrompt>().SetPromptTrigger(this);
    }
    public void LockDoors(float _seconds)
    {
        StartCoroutine(Disinfect());
        foreach (Script_Door door in Doors)
        {
            StartCoroutine(door.Lock(disInfectTime));
        }
    }
    public void ToggleInteracting(bool _interacting)
    {
        isInteracting = _interacting;
    }
    public bool IsInteracting()
    {
        return isInteracting; 
    }
    private void Awake()
    {
        Prompt.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject objectHit = other.gameObject;
        if (objectHit.tag == "Player" && !isDisinfecting)
        {
            Interact();
        }  
    }
    public bool bDisinfecting()
    {
        return isDisinfecting;
    }
    IEnumerator Disinfect()
    {
        isDisinfecting = true;
        yield return new WaitForSeconds(disInfectTime);
        isDisinfecting = false;
        isInteracting = false;
    }
    #endregion

    #region Public
    public void Interact()
    {
        isInteracting = true;
        Prompt.SetActive(true);
        PlayerScript.SetInteracting(true);
    }
    #endregion
}
