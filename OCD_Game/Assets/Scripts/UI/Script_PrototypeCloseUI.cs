using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PrototypeCloseUI : MonoBehaviour
{
    int iCounter = 0;
    [SerializeField] float fTimeTillClose = 0.2f;
    [SerializeField] Script_Player Player;
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

    private void Start()
    {
        Player = FindObjectOfType<Script_Player>();
    }

    private void Update()
    {
        if (UnlockCursor)
        {
            UnlockCursorFunction();
        }

        if (iCounter >= 6)
        {
            fCounterTillClose += Time.deltaTime;
            if (fCounterTillClose >= fTimeTillClose)
            {
                gameObject.SetActive(false);
                Player.SetInteracting(false);
                FindObjectOfType<Script_ThreatLevel>().DecreaseThreatLevel();
            }
        }
    }
}
