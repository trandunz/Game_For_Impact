using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_RefillFuel : MonoBehaviour
{
    [SerializeField] Image FuelMeter;
    bool canRefil = true;
    bool IsRefilling = false;
    private void OnEnable()
    {
        FuelMeter.fillAmount = Random.Range(0, 0.5f);
        canRefil = true;
        IsRefilling = false;
    }
    private void Update()
    {
        if (canRefil)
        {
            if (FuelMeter.fillAmount >= 1)
            {
                StartCoroutine(finishFilling());
            }
            else if (IsRefilling)
            {
                Refill();
            }
        }
    }
    public void OnButtonPress()
    {
        IsRefilling = true;
    }
    public void OnButtonUp()
    {
        IsRefilling = false;
    }
    void Refill()
    {
        if (FuelMeter != null)
        {
            FuelMeter.fillAmount += Time.deltaTime * 0.25f;
        }
    }
    IEnumerator finishFilling()
    {
        canRefil = false;
        IsRefilling = false;
        yield return new WaitForSeconds(2.0f);
        GetComponent<Script_BaseTaskPanel>().CloseTask(true);
    }
}
