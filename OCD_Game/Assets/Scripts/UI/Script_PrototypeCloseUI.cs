using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_PrototypeCloseUI : Script_BaseTaskPanel
{
    int iCounter = 0;
    [SerializeField] float fTimeTillClose = 0.2f;
    Script_PrototypeTaskDemo[] buttons;

    float fCounterTillClose = 0.0f;

    private void Awake()
    {
        buttons = GetComponentsInChildren<Script_PrototypeTaskDemo>();
    }

    public void Increment()
    {
        iCounter++;
    }

    private void Update()
    {
        if (iCounter >= 6)
        {
            fCounterTillClose += Time.deltaTime;
            if (fCounterTillClose >= fTimeTillClose)
            {
                foreach (Script_PrototypeTaskDemo button in buttons)
                {
                    button.ResetColor();
                }
                iCounter = 0;
                fCounterTillClose = 0;

                CloseTask(true);
                this.gameObject.SetActive(false);
            }
        }
    }
}
