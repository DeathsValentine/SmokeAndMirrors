using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    MainMenu menuScript;
    private GameObject bottomBar;
    private GameObject menuPanel;
    private GameObject optionPanel;

    public Text playerLevel;

    public Button ability1;
    public Button ability2;
    public Button ability3;

    public Sprite fireball;
    public Sprite freeze;
    public Sprite teleport;

    public Sprite dash;
    public Sprite bladeDance;
    public Sprite overwhelm;


    void Start()
    {
        Time.timeScale = 1;
        bottomBar = GameObject.Find("BottomBar");
        menuPanel = GameObject.Find("MenuPanel");
        optionPanel = GameObject.Find("OptionPanel");

        bottomBar.SetActive(true);
        menuPanel.SetActive(false);
        optionPanel.SetActive(false);

        Text playerName = GameObject.Find("PlayerName").GetComponent<Text>();
        Text playerClass = GameObject.Find("PlayerClass").GetComponent<Text>();
        playerLevel = GameObject.Find("PlayerLevel").GetComponent<Text>();

        playerName.text=PlayerPrefs.GetString("Username");//temp for better way
        playerLevel.text= "10";//temp value
        playerClass.text=PlayerPrefs.GetString("Character");
        
        if(PlayerPrefs.GetString("Character")=="Merlyn")
        {
            ability1.image.sprite=fireball;
            ability2.image.sprite=freeze;
            ability3.image.sprite=teleport;
        }
        if(PlayerPrefs.GetString("Character")=="Scarlett")
        {
            ability1.image.sprite=dash;
            ability2.image.sprite=bladeDance;
            ability3.image.sprite=overwhelm;
        }
    }

    void Update()
    {
        //when escape key on keyboard is pressed show menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("Escape Pressed");
            menuPanel.SetActive(!menuPanel.activeSelf);
            optionPanel.SetActive(false);
        }
    }

    public void OnMenuCall()
    {
        //Debug.Log("Menu Pressed");
        menuPanel.SetActive(!menuPanel.activeSelf);
    }
    public void OnOptionsCall()
    {
        //Debug.Log("Menu Pressed");
        menuPanel.SetActive(!menuPanel.activeSelf);
        optionPanel.SetActive(true);
    }


#region MenuPanel
    public void OnBackClick()
    {
        //Debug.Log("Menu Pressed");
        menuPanel.SetActive(!menuPanel.activeSelf);
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

#region OptionsPanel
    public void onOptionBack()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
        optionPanel.SetActive(false);
    }
#endregion
}
