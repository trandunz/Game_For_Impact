using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Script_PrototypeTaskDemo : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Color ClickedColor = Color.green;
    [SerializeField] Image Button;
    [SerializeField] Script_PrototypeCloseUI UIManager;
    void Start()
    {
        UIManager = GetComponentInParent<Script_PrototypeCloseUI>();
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (Button.color != ClickedColor)
        {
            Button.color = ClickedColor;
            UIManager.Increment();
        }
    }
}
