using System.Collections;
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
    [SerializeField] float amountRotated = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = radarHandle.GetComponent<RectTransform>();
        radarStartRotation = rectTransform.rotation;
        
    }

    private void OnEnable()
    {
        scanText.text = "COMMENCE SCAN";
        amountRotated = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isScanning)
        {
            amountRotated += 180 * Time.deltaTime;
            rectTransform.RotateAround(rectTransform.position, Vector3.back, 180 * Time.deltaTime);
        }
    }

    public void Scan()
    {
        if (scanText.text == "COMMENCE SCAN")
        {
            scanText.text = "COMMENCE SCAN \nSCANNING...";
            StartCoroutine(ScanRoutine());
        }
    }
    IEnumerator ScanRoutine()
    {
        isScanning = true;
        yield return new WaitUntil(() => (Mathf.Round(amountRotated) >= 720));

        StartCoroutine(FinishScanRoutine());
    }
    IEnumerator FinishScanRoutine()
    {
        isScanning = false;
        scanText.text = "COMMENCE SCAN\nSCANNING...\nNO DEBRIS FOUND";
        yield return new WaitForSeconds(1.0f);
        scanText.text = "COMMENCE SCAN\nSCANNING...\nNO DEBRIS FOUND\nSCAN COMPLETE";
        yield return new WaitForSeconds(1.0f);
        GetComponent<Script_BaseTaskPanel>().CloseTask(true);
        
    }
}
