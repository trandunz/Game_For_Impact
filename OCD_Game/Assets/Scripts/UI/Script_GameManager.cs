using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_GameManager : MonoBehaviour
{
    Script_Player player;
    [SerializeField] GameObject lossPanel;
    Script_ShipDestination shipDestination;

    private void Start()
    {
        player = FindObjectOfType<Script_Player>();
        shipDestination = FindObjectOfType<Script_ShipDestination>();
        lossPanel = Instantiate(lossPanel, FindObjectOfType<Canvas>().transform);
        lossPanel.SetActive(false);
    }

    private void Update()
    {
        if (shipDestination.GetProgress() >= 1.0f)
        {
            lossPanel.SetActive(true);
            player.SetInteracting(true);
        }
    }

}
