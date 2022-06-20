using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_EngineDials : MonoBehaviour
{
    [SerializeField] Button VoltageDial;
    [SerializeField] Button TankDial;
    [SerializeField] Button CoolingDial;
    bool voltageClicked = false;
    bool TankNobClicked = false;
    bool CoolingFanClicked = false;
    // Start is called before the first frame update
    void Start()
    {
        VoltageDial.onClick.AddListener(() => voltageClicked = true);
        TankDial.onClick.AddListener(() => TankNobClicked = true);
        CoolingDial.onClick.AddListener(() => CoolingFanClicked = true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            voltageClicked = false;
            TankNobClicked = false;
            CoolingFanClicked = false;
        }

        if (voltageClicked)
        {

        }
        if (TankNobClicked)
        {

        }
        if (CoolingFanClicked)
        {

        }
    }
}
