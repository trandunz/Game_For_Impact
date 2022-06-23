using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_OpeningEyes : MonoBehaviour
{
    Image BlackImage;
    bool IsFading;
    int TransitionDirection = 1;
    private void Start()
    {
        BlackImage = GetComponent<Image>();
        BlackImage.color = Color.black;
        StartCoroutine(Fade());
    }
    // Update is called once per frame
    void Update()
    {
        transform.SetSiblingIndex(transform.parent.childCount);
        if (IsFading)
        {
            Color currentColor = BlackImage.color;
            currentColor.a -= Time.deltaTime * 0.5f * TransitionDirection;
            BlackImage.color = currentColor;
        }
    }
    public bool IsScreenFading()
    {
        return IsFading;
    }
    public void CloseEyes()
    {
        if (!IsFading)
        {
            TransitionDirection = -1;
            StartCoroutine(Fade());
        }
    }
    IEnumerator Fade()
    {
        IsFading = true;
        yield return new WaitUntil(() => (TransitionDirection == 1 ? BlackImage.color.a <= 0 : BlackImage.color.a >= 1));
        IsFading = false;
    }
}
