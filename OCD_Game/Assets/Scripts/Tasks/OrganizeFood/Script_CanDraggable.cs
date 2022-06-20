using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Script_CanDraggable : MonoBehaviour
{
    Transform DropZone = null;
    Script_OrderFoodCans TaskScript;
    GameObject placeHolder;

    private void Start()
    {
        DropZone = transform.parent.transform;
        TaskScript = GetComponentInParent<Script_OrderFoodCans>();
    }

    public void OnBeginDrag()
    {
        placeHolder = Instantiate(new GameObject(), DropZone);
        placeHolder.transform.SetSiblingIndex(transform.GetSiblingIndex());
        LayoutElement layoutElement = placeHolder.AddComponent<LayoutElement>();
        layoutElement.preferredHeight = GetComponent<Image>().preferredHeight;
        layoutElement.preferredWidth = GetComponent<Image>().preferredWidth;
        layoutElement.flexibleHeight = 0;
        layoutElement.flexibleWidth = 0;
        transform.SetParent(TaskScript.transform);
    }

    public void OnDrag()
    {
        transform.position = Input.mousePosition;
        int newIndex = DropZone.childCount;
        for (int i = 0; i < DropZone.childCount; i++)
        {
            if (transform.position.x < DropZone.GetChild(i).position.x)
            {
                newIndex = i;

                if (placeHolder.transform.GetSiblingIndex() < newIndex)
                {
                    newIndex--;
                }

                break;
                
            }
        }
        placeHolder.transform.SetSiblingIndex(newIndex);
    }

    public void OnEndDrag()
    {
        transform.SetParent(DropZone);
        transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
        Destroy(placeHolder);
    }
}

