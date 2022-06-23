using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_EngineDials : MonoBehaviour
{
    [SerializeField] Script_Dial VoltageDial;
    [SerializeField] Script_Dial TankDial;
    [SerializeField] Script_Dial CoolingDial;

    float angle = 0.0f;
    bool canChangeDials = true;


    private void Start()
    {
        VoltageDial.SetDialValue(angle);
        TankDial.SetDialValue(angle);
        CoolingDial.SetDialValue(angle);
    }

    private void OnEnable()
    { 
        canChangeDials = true;
    }

    private void Update()
    {
        if (VoltageDial.ReachedDesiredValue() &&
            TankDial.ReachedDesiredValue() &&
            CoolingDial.ReachedDesiredValue() && canChangeDials)
        {
            StartCoroutine(TurnedAllDialsRoutine());
            
        }
    }

    public void onHandleDrag(Image _dialDragged)
    {
        if (canChangeDials)
        {
            Vector3 mousepos = Input.mousePosition;
            Vector2 direction = (mousepos - _dialDragged.transform.position);
            angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            angle = Mathf.Round(angle);
            angle = angle < 0 ? 360 + angle : angle;
            angle = RoundToNearestMultiple(angle, 30);
            if (angle / 30 == 12)
            {
                angle = 0;
            }
            _dialDragged.transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
            _dialDragged.GetComponentInParent<Script_Dial>().SetDialValue(angle / 30);

        }
        
    }

    IEnumerator TurnedAllDialsRoutine()
    {
        canChangeDials = false;
        yield return new WaitForSeconds(2);
        GetComponent<Script_BaseTaskPanel>().CloseTask(true);
    }

    float RoundToNearestMultiple(float _value, float multiple)
    {
        float rem = _value % multiple;
        float result = _value - rem;
        if (rem >= (multiple / 2))
            result += multiple;
        return result;
    }
}
