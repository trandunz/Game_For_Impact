using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Rotate : MonoBehaviour
{
    [SerializeField] float fRotateSpeed;
    [SerializeField] Light PointLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, fRotateSpeed * Time.deltaTime, 0);
    }
}
