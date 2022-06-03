using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_GameManager : MonoBehaviour
{
    Script_Player player;
    [SerializeField] GameObject lossPanel;

    private void Start()
    {
        player = FindObjectOfType<Script_Player>();
        lossPanel = Instantiate(lossPanel, FindObjectOfType<Canvas>().transform);
        lossPanel.SetActive(false);
    }

    private void Update()
    {
    }

}
