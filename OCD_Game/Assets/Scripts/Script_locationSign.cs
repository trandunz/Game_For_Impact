using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_locationSign : MonoBehaviour
{
    [SerializeField] string Text;
    TMPro.TextMeshPro[] Texts;
    private void Start()
    {
        Texts = GetComponentsInChildren<TMPro.TextMeshPro>();
        foreach(var text in Texts)
        {
            text.text = Text;
        }
    }
}
