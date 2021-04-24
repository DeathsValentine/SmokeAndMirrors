using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private GameObject bottomBar;
    private GameObject menuPanel;
    private GameObject inventoryPanel;

    public Button ability1;
    public Button ability2;
    public Button ability3;

    public Sprite fireball;
    public Sprite freeze;
    public Sprite teleport;

    void Start()
    {
        Time.timeScale = 1;
        bottomBar = GameObject.Find("BottomBar");
        menuPanel = GameObject.Find("MenuPanel");
        inventoryPanel = GameObject.Find("InventoryPanel");

        bottomBar.SetActive(true);
        menuPanel.SetActive(false);
        
        if(PlayerPrefs.GetString("Character")=="Merlyn")
        {
            ability1.image.sprite=fireball;
            ability2.image.sprite=freeze;
            ability3.image.sprite=teleport;
        }
    }

    void Update()
    {
        //when escape key on keyboard is pressed show menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("Escape Pressed");
            menuPanel.SetActive(!menuPanel.activeSelf);
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }


    public void OnMenuCall()
    {
        Debug.Log("Menu Pressed");
        menuPanel.SetActive(!menuPanel.activeSelf);
    }

#region MenuPanel
    public void OnBackClick()
    {
        //Debug.Log("Menu Pressed");
        menuPanel.SetActive(!menuPanel.activeSelf);
    }

    public void OnInventoryClick()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    public void OnQuitClick()
    {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }
#endregion
}
