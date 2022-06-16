using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_TaskOrientShip : MonoBehaviour
{
    [SerializeField] Image ship;
    [SerializeField] Image destination;
    [SerializeField] Image SliderHandle;
    Vector3 ShipStartPos;
    bool doOnce = false;
    bool canSteer = true;
    float sliderValue = 0.5f;

    private void OnEnable()
    {
        if (!doOnce)
        {
            SliderHandle.GetComponentInParent<Slider>().onValueChanged.AddListener(SliderValueChanged);
            doOnce = true;
            ShipStartPos = ship.rectTransform.position;
        }
        destination.rectTransform.position = new Vector3(ShipStartPos.x + Random.Range(-300, 300), destination.rectTransform.position.y, destination.rectTransform.position.z);
        canSteer = true;
    }
    // Update is called once per frame

    void Update()
    {
        if (canSteer == false)
        {
            Slider slider = SliderHandle.GetComponentInParent<Slider>();
            if (slider)
            {
                slider.value = sliderValue;
            }
        }
    }

    public void SliderValueChanged(float _value)
    {
        if (canSteer)
        {
            sliderValue = _value;
            ship.rectTransform.position = new Vector3(SliderHandle.rectTransform.position.x, ship.rectTransform.position.y, ship.rectTransform.position.z);
            if (ship.rectTransform.position.x <= destination.rectTransform.position.x + 10
                && ship.rectTransform.position.x >= destination.rectTransform.position.x - 10)
            {
                canSteer = false;
                GetComponent<Script_BaseTaskPanel>().CloseTask(true);
            }
        }
    }
}
