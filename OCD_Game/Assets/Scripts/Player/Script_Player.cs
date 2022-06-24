using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player : MonoBehaviour
{
    #region Private
    RaycastHit InteractHit;
    Camera FPSCamera;
    bool IsInteractingWithTask = false;
    Script_InteractionText InteractionText;
    Script_TaskPanel TaskList;

    public string PlayerLocation = "Common Space";

    [SerializeField] float InteractionDistance = 3.0f;
    private void Start()
    {
        TaskList = FindObjectOfType<Script_TaskPanel>();
        FPSCamera = GetComponentInChildren<Camera>();
        InteractionText = FindObjectOfType<Script_InteractionText>();
    }
    private void Update()
    {
        Interact();
    }
    private void Interact()
    {
        if (InteractionText)
            InteractionText.ClearInteractionText();

        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out InteractHit, InteractionDistance))
        {
            Transform hitTransform = InteractHit.transform;
            if (hitTransform.tag == "Interactable")
            {
                Script_TaskInteractable interactableScript = hitTransform.GetComponent<Script_TaskInteractable>();
                if (Input.GetKeyDown(KeyCode.E) && !IsInteractingWithTask)
                {
                    Debug.Log("Interacted!");
                    IsInteractingWithTask = true;
                    interactableScript.Interact();
                }
                else if (!IsInteractingWithTask)
                {
                    if (InteractionText)
                        InteractionText.ShowInteractionText();
                }
            }
            if (hitTransform.tag == "KeyPad")
            {
                Script_Keypad keypadScript = hitTransform.GetComponent<Script_Keypad>();
                if (Input.GetKeyDown(KeyCode.E) && !IsInteractingWithTask)
                {
                    keypadScript.Interact();
                }
                else
                {
                    if (InteractionText)
                        InteractionText.ShowInteractionText();
                }
            }
        }
    }

    #endregion

    #region Public
    public bool IsInteracting()
    {
        return IsInteractingWithTask;
    }
    public void SetInteracting(bool _isInteracting)
    {
        IsInteractingWithTask = _isInteracting;

        if (IsInteractingWithTask == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void SetCharacterControllerActive(bool _active)
    {
        GetComponentInChildren<CharacterController>().gameObject.SetActive(_active);
    }
    #endregion
}
