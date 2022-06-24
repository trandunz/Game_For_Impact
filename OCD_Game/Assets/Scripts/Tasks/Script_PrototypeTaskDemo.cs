// Description: Placed on a button to allow it to function as aprt of the task
//
// made by: Josh

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Script_PrototypeTaskDemo : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Color ClickedColor = Color.green;
    [SerializeField] Image Button;
    Color startingColor;
    [SerializeField] Script_PrototypeCloseUI UIManager;

    void Start()
    {
        // get the needed info
        UIManager = GetComponentInParent<Script_PrototypeCloseUI>();
        startingColor = Button.color;
    }

    /// <summary>
    /// change the button color when it is clicked, and increment the counter in the CloseTask script
    /// </summary>
    /// <param name="pointerEventData"></param>
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (Button.color != ClickedColor)
        {
            Button.color = ClickedColor;
            UIManager.Increment();
        }
    }

    /// <summary>
    /// set the color back to its default
    /// </summary>
    public void ResetColor()
    {
        Button.color = startingColor;
    }
}
