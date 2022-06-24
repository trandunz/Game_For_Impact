using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Script_PauseMenu : MonoBehaviour
{
    [SerializeField] Sprite isOpenSprite;
    [SerializeField] Sprite isClosedSprite;
    [SerializeField] Image isOpenImage;
    [SerializeField] GameObject buttons;

    Script_Player player;
    bool isOpen = false;

    public void SetIsOpen(bool _isOpen)
    {
        isOpen = _isOpen;
        if (isOpen)
        {
            player.SetInteracting(true);
        }
        else
        {
            player.SetInteracting(false);
        }
    }
    public bool IsPaused()
    {
        return isOpen;
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void Start()
    {
        player = FindObjectOfType<Script_Player>();
        
    }
    private void Awake()
    {
        buttons.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !player.IsInteracting())
        {
            SetIsOpen(!isOpen);
        }
        
        buttons.SetActive(isOpen);
        if (isOpen)
        {
            isOpenImage.sprite = isOpenSprite;
        }
        else
        {
            isOpenImage.sprite = isClosedSprite;
        }
    }
}
