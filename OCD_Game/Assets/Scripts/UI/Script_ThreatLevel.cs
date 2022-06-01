using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_ThreatLevel : MonoBehaviour
{
    #region Private
    float ThreatlLevel;
    float ThreatPauseTimer = 0.0f;
    Script_PauseMenu PauseMenu;
    [SerializeField] Image[] ThreatImages;
    [SerializeField] Image MaxThreat;
    [SerializeField] float ThreatLevelPerSecond;
    [SerializeField] float ThreatPauseTime = 0.0f;

    void Start()
    {
        PauseMenu = FindObjectOfType<Script_PauseMenu>();
        foreach (Image image in ThreatImages)
        {
            image.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.IsPaused())
        {
            if (ThreatPauseTimer > 0)
            {
                ThreatPauseTimer -= Time.deltaTime;
            }
            else if (ThreatlLevel < ThreatImages.Length)
            {
                ThreatlLevel += Time.deltaTime * ThreatLevelPerSecond;
            }

            foreach (Image image in ThreatImages)
            {
                image.gameObject.SetActive(false);
            }
            for (int i = 0; i < (int)(ThreatlLevel); i++)
            {
                if (i < ThreatImages.Length)
                    ThreatImages[i].gameObject.SetActive(true);
                else
                    break;
            }
            if (ThreatImages[ThreatImages.Length - 1].isActiveAndEnabled)
                MaxThreat.gameObject.SetActive(true);
            else
                MaxThreat.gameObject.SetActive(false);
        }
    }
    #endregion

    #region Public
    public void DecreaseThreatLevel()
    {
        ThreatlLevel -= (ThreatImages.Length / 5);
        ThreatPauseTimer = ThreatPauseTime;
        if (ThreatlLevel <= 0)
        {
            ThreatlLevel = 0;
        }
    }
    #endregion
}
