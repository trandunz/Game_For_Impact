using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_GameManager : MonoBehaviour
{
    Script_Player player;
    [SerializeField] GameObject lossPanel;
    Script_ShipDestination shipDestination;
    Script_TaskPanel TaskPanel;
    Script_DisinfectRoomManager DisinfectRoomManager;

    private void Start()
    {
        player = FindObjectOfType<Script_Player>();
        shipDestination = FindObjectOfType<Script_ShipDestination>();
        lossPanel = Instantiate(lossPanel, FindObjectOfType<Canvas>().transform);
        lossPanel.SetActive(false);
        TaskPanel = FindObjectOfType<Script_TaskPanel>();
        DisinfectRoomManager = FindObjectOfType<Script_DisinfectRoomManager>();
    }

    private void Update()
    {
        if (shipDestination.GetProgress() >= 1.0f)
        {
            lossPanel.SetActive(true);
            player.SetInteracting(true);
            //TaskPanel.StopAlarms();
            //DisinfectRoomManager.StopAllWarnings();
        }
    }

}
