using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_GameManager : MonoBehaviour
{
    Script_ThreatLevel threatLevel;
    Script_Player player;
    [SerializeField] GameObject lossPanel;

    private void Start()
    {
        threatLevel = FindObjectOfType<Script_ThreatLevel>();
        player = FindObjectOfType<Script_Player>();
        lossPanel = Instantiate(lossPanel, FindObjectOfType<Canvas>().transform);
        lossPanel.SetActive(false);
    }

    private void Update()
    {
        if (threatLevel.GetThreatLevel() >= 1.0f)
        {
            player.SetInteracting(true);

            // Game Over
            lossPanel.SetActive(true);
        }
    }

}
