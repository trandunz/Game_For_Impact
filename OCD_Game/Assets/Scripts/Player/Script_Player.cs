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

    [SerializeField] float InteractionDistance = 3.0f;
    private void Start()
    {
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
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Interacted!");
                    IsInteractingWithTask = true;
                    hitTransform.GetComponent<Script_TaskInteractable>().Interact();
                }
                else if (!IsInteractingWithTask)
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
    }
    public void SetCharacterControllerActive(bool _active)
    {
        GetComponentInChildren<CharacterController>().gameObject.SetActive(_active);
    }
    #endregion
}
