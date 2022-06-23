using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_CheckTemp : MonoBehaviour
{
    [SerializeField] Button ScanButton;
    [SerializeField] Text GuageTemp;
    bool scanning = false;

    private void OnEnable()
    {
        GuageTemp.color = Color.black;
        ScanButton.gameObject.SetActive(true);
        scanning = false;
    }
    private void Update()
    {
        if (scanning)
        {
            GuageTemp.text = Random.Range(-10, 35).ToString();
        }
    }
    public void OnScanTemp()
    {
        if (!scanning)
        {
            StartCoroutine(CheckTemp());
        }
    }
    IEnumerator CheckTemp()
    {
        GuageTemp.color = Color.red;
        scanning = true;
        yield return new WaitForSeconds(Random.Range(3,5));
        scanning = false;
        GuageTemp.text = "25 C";
        GuageTemp.color = Color.green;
        yield return new WaitForSeconds(2.0f);
        GetComponent<Script_BaseTaskPanel>().CloseTask(true);

    }
}
