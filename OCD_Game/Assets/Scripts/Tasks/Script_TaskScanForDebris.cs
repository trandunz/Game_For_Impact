using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_TaskScanForDebris : MonoBehaviour
{
    [SerializeField] GameObject radarHandle;
    bool isScanning = false;
    Quaternion radarStartRotation;
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = radarHandle.GetComponent<RectTransform>();
        radarStartRotation = rectTransform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (isScanning && rectTransform.rotation != radarStartRotation)
        {
            rectTransform.RotateAround(rectTransform.position, Vector3.back, 180 * Time.deltaTime);
        }
    }

    public void Scan()
    {
        if (!isScanning)
        {
            StartCoroutine(ScanRoutine());
        }
    }
    IEnumerator ScanRoutine()
    {
        rectTransform.RotateAround(rectTransform.position, Vector3.back, 180 * Time.deltaTime);
        isScanning = true;
        yield return new WaitUntil(() => rectTransform.rotation == radarStartRotation);
        isScanning = false;
        GetComponent<Script_BaseTaskPanel>().CloseTask(true);
    }
}
