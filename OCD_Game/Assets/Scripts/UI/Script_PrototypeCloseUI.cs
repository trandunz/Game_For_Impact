// Description: Closes the Prototype UI a set time after the task has finished.
//
// made by: Josh

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PrototypeCloseUI : Script_BaseTaskPanel
{
    int iCounter = 0;
    [SerializeField] float fTimeTillClose = 0.2f;

    // array of the buttons used in the prototype task
    Script_PrototypeTaskDemo[] buttons;

    float fCounterTillClose = 0.0f;

    private void Awake()
    {
        // gets array of buttons
        buttons = GetComponentsInChildren<Script_PrototypeTaskDemo>();
    }

    /// <summary>
    /// called by the prototype demo to increase the counter
    /// </summary>
    public void Increment()
    {
        iCounter++;
    }

    private void Update()
    {
        // checks if each button has been pressed
        if (iCounter >= 6)
        {
            // start the timer till the UI closes
            fCounterTillClose += Time.deltaTime;
            if (fCounterTillClose >= fTimeTillClose)
            {
                // reset the task
                foreach (Script_PrototypeTaskDemo button in buttons)
                {
                    button.ResetColor();
                }
                iCounter = 0;
                fCounterTillClose = 0;

                CloseTask(true);
                gameObject.SetActive(false);
            }
        }
    }
}
