// Description: Manages which menu is open on the title screen.
//
// made by: 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject SettingsMenu;

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
