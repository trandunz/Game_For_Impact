using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player : MonoBehaviour
{
    #region Private
    RaycastHit InteractHit;
    Camera FPSCamera;
    bool IsInteractingWithTask = false;

    [SerializeField] float InteractionDistance = 3.0f;
    private void Start()
    {
        FPSCamera = GetComponentInChildren<Camera>();
    }
    private void Interact()
    {
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out InteractHit, InteractionDistance))
        {
            Transform hitTransform = InteractHit.transform;
            if (hitTransform.tag == "Interactable")
            {
                IsInteractingWithTask = true;
                hitTransform.GetComponent<Script_TaskInteractable>().Interact();
            }
        }
    }

    #endregion

    #region Public
    public bool IsInteracting()
    {
        return IsInteractingWithTask;
    }
    #endregion
}
