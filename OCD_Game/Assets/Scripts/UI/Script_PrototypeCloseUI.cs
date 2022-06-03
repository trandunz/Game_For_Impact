using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PrototypeCloseUI : Script_BaseTaskPanel
{
    int iCounter = 0;
    [SerializeField] float fTimeTillClose = 0.2f;   
    [SerializeField] bool UnlockCursor;

    float fCounterTillClose = 0.0f;

    public void Increment()
    {
        iCounter++;
    }

    public void UnlockCursorFunction()
    {
        Cursor.lockState = CursorLockMode.None;
        UnlockCursor = false;
        Player.SetInteracting(true);
    }

    private void Update()
    {
        if (iCounter >= 6)
        {
            fCounterTillClose += Time.deltaTime;
            if (fCounterTillClose >= fTimeTillClose)
            {
                CloseTask(true);
                this.gameObject.SetActive(false);
            }
        }
    }
}
