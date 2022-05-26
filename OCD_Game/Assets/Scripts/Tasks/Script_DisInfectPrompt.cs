﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_DisInfectPrompt : MonoBehaviour
{
    #region Private
    [SerializeField] GameObject Prompt;
    Script_Player PlayerScript;
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
        Prompt.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject objectHit = other.gameObject;
        if (objectHit.tag == "Player")
        {
            //objectHit.transform.position = gameObject.transform.root.position;
            objectHit.GetComponentInChildren<Camera>().transform.rotation = Quaternion.Euler(0, 90, 0);
            Interact();
        }  
    }
    #endregion

    #region Public
    public void Interact()
    {
        Prompt.SetActive(true);
        PlayerScript.SetInteracting(true);
        Cursor.lockState = CursorLockMode.None;
    }
    #endregion
}
