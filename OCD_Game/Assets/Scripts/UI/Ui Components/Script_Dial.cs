using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_Dial : MonoBehaviour
{
    [SerializeField] Text DialValue;
    int desiredValue = 0;
    int value = 0;
    void OnEnable()
    {
        SetDesiredValue(Random.Range(0, 360));
    }
    public void SetDialValue(float _value)
    {
        value = Mathf.RoundToInt(_value);
        DialValue.text = value.ToString();
    }
    public void SetDesiredValue(int _value)
    {
        desiredValue = _value;
    }
    private void Update()
    {
        if (desiredValue == value)
        {
            GetComponent<Image>().color = Color.green;
        }
        else
        {
            GetComponent<Image>().color = Color.red;
        }
    }
    public bool ReachedDesiredValue()
    {
        if (desiredValue == value)
        {
            return true;
        }
        
        return false;
    }
}
