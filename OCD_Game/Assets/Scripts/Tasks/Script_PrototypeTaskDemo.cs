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
        UIManager = GetComponentInParent<Script_PrototypeCloseUI>();
        startingColor = Button.color;
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (Button.color != ClickedColor)
        {
            Button.color = ClickedColor;
            UIManager.Increment();
        }
    }
    public void ResetColor()
    {
        Button.color = startingColor;
    }
}
