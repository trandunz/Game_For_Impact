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
        // get the trigger text and calculate how much to lower the alpha by
        TriggerText = TriggerWarning.GetComponentInChildren<Text>();
        fDifferInAlpha = TriggerText.color.r * fTriggerWarningTime * 0.2f;

        // check if the trigger warning screen has alread been played
        if (PlayedTriggerWarning)
        {
            MainMenu.SetActive(true);
            TriggerWarning.SetActive(false);
            fTriggerWarningCounter = fTriggerWarningTime;
        }
    }

    private void Update()
    {
        // check if the trigger warning has finished playing
        if (fTriggerWarningTime > fTriggerWarningCounter)
        {
            fTriggerWarningCounter += Time.deltaTime;

            // if the user clicks the mouse, skip to the time in the counter to start the text fade
            if (Input.GetMouseButtonDown(0) && fTriggerWarningCounter > 0.2f && fTriggerWarningCounter < fTriggerWarningTime * 0.85f)
            {
                if (TriggerWarning.activeSelf)
                {
                    fTriggerWarningCounter = fTriggerWarningTime * 0.85f;
                }
            }

            // check if the text should start fading
            if (fTriggerWarningCounter > fTriggerWarningTime * 0.85)
            {
                TriggerText.color = new Color(TriggerText.color.r, TriggerText.color.g, TriggerText.color.b, TriggerText.color.a - fDifferInAlpha * Time.deltaTime);
            }

            // check if the manager needs to load the main menu
            if (fTriggerWarningTime <= fTriggerWarningCounter)
            {
                MainMenu.SetActive(true);
                TriggerWarning.SetActive(false);
                // used to make sure the trigger warning only plays once on launch.
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
