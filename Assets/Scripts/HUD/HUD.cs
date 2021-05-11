using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    MainMenu menuScript;
    private GameObject bottomBar;
    private GameObject menuPanel;
    private GameObject optionPanel;
    private GameObject statsPanel;

    public Text playerLevel;

    private Text enduranceVal;
    private Text strengthVal;
    private Text intelligenceVal;
    private Text dexterityVal;

    public Button ability1;
    public Button ability2;
    public Button ability3;

    private Image charImage;

    public Sprite merlyn;
    public Sprite scarlett;

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
        statsPanel = GameObject.Find("StatsPanel");

        bottomBar.SetActive(true);
        menuPanel.SetActive(false);
        optionPanel.SetActive(false);
        statsPanel.SetActive(false);

        Text playerName = GameObject.Find("PlayerName").GetComponent<Text>();
        Text playerClass = GameObject.Find("PlayerClass").GetComponent<Text>();
        playerLevel = GameObject.Find("PlayerLevel").GetComponent<Text>();

        charImage= GameObject.Find("CharacterImage").GetComponent<Image>();

        playerName.text=Player.playerName;
        //Debug.Log(PlayerPrefs.GetInt("Level"));
        playerLevel.text= Player.level.ToString();
        playerClass.text=PlayerPrefs.GetString("Character");
        
        if(PlayerPrefs.GetString("Character")=="Merlyn")
        {
            charImage.sprite=merlyn;
            ability1.image.sprite=fireball;
            ability2.image.sprite=freeze;
            ability3.image.sprite=teleport;
        }
        if(PlayerPrefs.GetString("Character")=="Scarlett")
        {
            charImage.sprite=scarlett;
            ability1.image.sprite=dash;
            ability2.image.sprite=bladeDance;
            ability3.image.sprite=overwhelm;
        }
    }

    void Update()
    {
        Text location = GameObject.Find("Location").GetComponent<Text>();
        location.text= SceneManager.GetActiveScene().name;

        //when escape key on keyboard is pressed show menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
             if(optionPanel.activeSelf==true)
            {
                menuPanel.SetActive(!menuPanel.activeSelf);
                optionPanel.SetActive(false);
            }
            if(statsPanel.activeSelf==true)
            {
                statsPanel.SetActive(false);
            }
            else
            {
                menuPanel.SetActive(!menuPanel.activeSelf);
            }
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
    public void OnStatsCall()
    {
        statsPanel.SetActive(true);
        enduranceVal =GameObject.Find("EnduranceValue").GetComponent<Text>();
        strengthVal =GameObject.Find("StrengthValue").GetComponent<Text>();
        intelligenceVal =GameObject.Find("IntelligenceValue").GetComponent<Text>();
        dexterityVal =GameObject.Find("DexterityValue").GetComponent<Text>();

        enduranceVal.text=Player.Endurance.ToString();
        strengthVal.text=Player.Strength.ToString();
        intelligenceVal.text=Player.Intelligence.ToString();
        dexterityVal.text=Player.Dexterity.ToString();
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

#region StatsPanel
    public void onStatBack()
    {
        statsPanel.SetActive(false);
    }
#endregion
}
