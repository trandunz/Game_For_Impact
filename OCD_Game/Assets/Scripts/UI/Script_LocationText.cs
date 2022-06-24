using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_LocationText : MonoBehaviour
{
    Script_Player PlayerScript;
    Text LocationText;
    void Start()
    {
        PlayerScript = FindObjectOfType<Script_Player>();
        LocationText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        LocationText.text = PlayerScript.PlayerLocation;
    }
}
