using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_OrderFoodCans : MonoBehaviour
{
    Transform dropzone;
    bool Inorder = false;
    void Start()
    {
        dropzone = GetComponentInChildren<Script_CanDraggable>().transform.parent;
    }
    private void OnEnable()
    {
        if (dropzone == null)
            dropzone = GetComponentInChildren<Script_CanDraggable>().transform.parent;

        for (int i = 0; i < dropzone.childCount; i++)
        {
            dropzone.GetChild(i).SetSiblingIndex(Random.Range(0, dropzone.childCount));
        }
        Inorder = false;
    }
    private void Update()
    {
        if (Inorder == false)
        {
            float previousHeight = 0.0f;
            for (int i = 0; i < dropzone.childCount; i++)
            {
                if(dropzone.GetChild(i).GetComponent<Image>() == null)
                {
                    continue;
                }
                if (dropzone.GetChild(i).GetComponent<Image>().rectTransform.rect.height > previousHeight)
                {
                    previousHeight = dropzone.GetChild(i).GetComponent<Image>().rectTransform.rect.height;
                    Inorder = true;
                }
                else
                {
                    Inorder = false;
                    break;
                }
            }

            if (Inorder == true)
            {
                StartCoroutine(CloseRoutine());
            }
        }
    }

    IEnumerator CloseRoutine()
    {
        yield return new WaitForSeconds(2);
        GetComponent<Script_BaseTaskPanel>().CloseTask(true);
    }
}
