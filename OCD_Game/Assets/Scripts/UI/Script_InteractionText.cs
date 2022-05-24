using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_InteractionText : MonoBehaviour
{
    #region Private
    Text InteractionText;
    void Start()
    {
        InteractionText = GetComponentInChildren<Text>();
        InteractionText.text = "";
    }
    #endregion

    #region Public
    public void ShowInteractionText()
    {
        InteractionText.text = "Press [E] To Interact";
    }
    public void ClearInteractionText()
    {
        InteractionText.text = "";
    }
    #endregion
}
