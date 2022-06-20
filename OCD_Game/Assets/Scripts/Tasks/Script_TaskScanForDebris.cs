﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_TaskScanForDebris : MonoBehaviour
{
    [SerializeField] GameObject radarHandle;
    [SerializeField] Text scanText;
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
        if (!isScanning)
        {
            scanText.text = "COMMENCE SCAN";
        }
        if (isScanning && rectTransform.rotation != radarStartRotation)
        {
            rectTransform.RotateAround(rectTransform.position, Vector3.back, 180 * Time.deltaTime);
        }
    }

    public void Scan()
    {
        if (!isScanning)
        {
            scanText.text = "COMMENCE SCAN \nSCANNING...";
            StartCoroutine(ScanRoutine());
        }
    }
    IEnumerator ScanRoutine()
    {
        rectTransform.RotateAround(rectTransform.position, Vector3.back, 180 * Time.deltaTime);
        isScanning = true;
        yield return new WaitUntil(() => rectTransform.rotation == radarStartRotation);

        StartCoroutine(FinishScanRoutine());
    }
    IEnumerator FinishScanRoutine()
    {
        scanText.text = "COMMENCE SCAN\nSCANNING...\nNO DEBRIS FOUND";
        yield return new WaitForSeconds(1.0f);
        scanText.text = "COMMENCE SCAN\nSCANNING...\nNO DEBRIS FOUND\nSCAN COMPLETE";
        yield return new WaitForSeconds(1.0f);
        isScanning = false;
        GetComponent<Script_BaseTaskPanel>().CloseTask(true);
    }
}
