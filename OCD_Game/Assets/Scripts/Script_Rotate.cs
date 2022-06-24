// Description: Rotates the parent object of the light, rotating the light in a circle
//
// made by: Josh

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Rotate : MonoBehaviour
{
    // variables
    [SerializeField] float fRotateSpeed;
    [SerializeField] Light PointLight1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, fRotateSpeed * Time.deltaTime, 0);
    }

    public void EnableLight()
    {
        PointLight1.gameObject.SetActive(true);
    }

    public void DisableLight()
    {
        PointLight1.gameObject.SetActive(false);
    }
}
