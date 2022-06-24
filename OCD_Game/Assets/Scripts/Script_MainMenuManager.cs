// Description: Manages which menu is open on the title screen.
//
// made by: 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_MainMenuManager : MonoBehaviour
{
    static bool PlayedTriggerWarning = false;
    [SerializeField] float fTriggerWarningTime = 10.0f;
    float fTriggerWarningCounter = 0.0f;
    [SerializeField] float fDifferInAlpha;

    // screens
    [SerializeField] GameObject TriggerWarning;
    [SerializeField] Text TriggerText;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject SettingsMenu;

    private void Start()
    {
        TriggerText = TriggerWarning.GetComponentInChildren<Text>();
        fDifferInAlpha = TriggerText.color.r * fTriggerWarningTime * 0.2f;
        if (PlayedTriggerWarning)
        {
            MainMenu.SetActive(true);
            TriggerWarning.SetActive(false);
            fTriggerWarningCounter = fTriggerWarningTime;
        }
    }

    private void Update()
    {
        if (fTriggerWarningTime > fTriggerWarningCounter)
        {
            fTriggerWarningCounter += Time.deltaTime;

            if (Input.GetMouseButtonDown(0) && fTriggerWarningCounter > 0.5f && fTriggerWarningCounter < fTriggerWarningTime * 0.8f)
            {
                if (TriggerWarning.activeSelf)
                {
                    fTriggerWarningCounter = fTriggerWarningTime * 0.8f;
                }
            }

            if (fTriggerWarningCounter > fTriggerWarningTime * 0.9)
            {
                TriggerText.color = new Color(TriggerText.color.r, TriggerText.color.g, TriggerText.color.b, TriggerText.color.a - fDifferInAlpha * Time.deltaTime);
            }

            if (fTriggerWarningTime <= fTriggerWarningCounter)
            {
                MainMenu.SetActive(true);
                TriggerWarning.SetActive(false);
                PlayedTriggerWarning = true;
            }
        }
    }

    /// <summary>
    /// enables the setting menu, and disables the main menu
    /// </summary>
    public void OpenSettings()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    /// <summary>
    /// enables the main menu, and disables the setting menu
    /// </summary>
    public void CloseSettings()
    {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }
}
