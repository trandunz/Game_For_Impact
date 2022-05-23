﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_FirstPersonMotor : MonoBehaviour
{
    #region Private
    Camera FirstPersonCamera;
    GameObject Mesh;
    CharacterController CharacterController;
    Script_Player Player;

    float xMouseRotation = 0.0f;
    float yMouseRotation = 0.0f;

    [SerializeField] float MovementSpeed = 10.0f;
    [SerializeField] float GravityStrength = -9.81f;
    [SerializeField] float LookSensitivity = 1.0f;

    private void Start()
    {
        FirstPersonCamera = GetComponentInChildren<Camera>();
        Mesh = GetComponentInChildren<MeshRenderer>().gameObject;
        CharacterController = GetComponent<CharacterController>();
        Player = GetComponent<Script_Player>();

        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        ApplyGravity();
        if (!Player.IsInteracting())
        {
            Vector3 input = Quaternion.Euler(0.0f, xMouseRotation, 0.0f) * GetMovementInput();
            HandleFPSCamera();
            if (input.magnitude > 0)
            {
                CharacterController.Move(input * MovementSpeed * Time.deltaTime);
            }
        }
    }
    private Vector3 GetMovementInput()
    {
        Vector3 input = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            input.z += 1;
        if (Input.GetKey(KeyCode.S))
            input.z -= 1;
        if (Input.GetKey(KeyCode.A))
            input.x -= 1;
        if (Input.GetKey(KeyCode.D))
            input.x += 1;
        return input.normalized;
    }
    private void ApplyGravity()
    {
        CharacterController.Move(new Vector3(0, GravityStrength, 0) * Time.deltaTime);
    }
    private void HandleFPSCamera()
    {
        xMouseRotation += Input.GetAxisRaw("Mouse X") * LookSensitivity;
        yMouseRotation -= Input.GetAxisRaw("Mouse Y") * LookSensitivity;
        yMouseRotation = Mathf.Clamp(yMouseRotation, -85, 85);
        FirstPersonCamera.transform.localEulerAngles = new Vector3(yMouseRotation, xMouseRotation, 0.0f);
    }
    #endregion
}
