using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_FirstPersonMotor : MonoBehaviour
{
    #region Private
    Camera FirstPersonCamera;
    GameObject Mesh;

    private void Start()
    {
        FirstPersonCamera = GetComponentInChildren<Camera>();
        Mesh = GetComponentInChildren<MeshRenderer>().gameObject;
    }
    Vector2 GetMovementInput()
    {
        Vector2 input = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
            input.y += 1;
        if (Input.GetKey(KeyCode.S))
            input.y -= 1;
        if (Input.GetKey(KeyCode.A))
            input.x -= 1;
        if (Input.GetKey(KeyCode.D))
            input.x += 1;
        return input.normalized;
    }
    #endregion
}
