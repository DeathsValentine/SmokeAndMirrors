using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private GameObject bottomBar;
    private GameObject playerBar;
    private GameObject menuPanel;
    private GameObject optionPanel;
    
    public Button ability1;
    public Button ability2;
    public Button ability3;

    public Image characterImage;
    public Sprite merlynImage;
    public Sprite scarlettImage;

    public Sprite fireball;
    public Sprite freeze;
    public Sprite teleport;

    public Sprite dash;
    public Sprite bladeDance;
    public Sprite overwhelm;

    void Start()
    {
        playerBar = GameObject.Find("PlayerBar");
        bottomBar = GameObject.Find("BottomBar");
        menuPanel = GameObject.Find("MenuPanel");
        optionPanel = GameObject.Find("OptionPanel");

        Text nameField= GameObject.Find("NameField").GetComponent<Text>();
        Text characterField= GameObject.Find("CharacterField").GetComponent<Text>();
        Text levelField= GameObject.Find("LevelField").GetComponent<Text>();

        playerBar.SetActive(true);
        bottomBar.SetActive(true);
        menuPanel.SetActive(false);
        optionPanel.SetActive(false);

        //changing Text fields
        nameField.text="Player1";   //temp for actual player name in database
        levelField.text="10";       //temp for actual player level in database
        
        if(PlayerPrefs.GetString("Character")=="Merlyn") //temp for getting player chosen character from database
        {
            characterField.text="Merlyn";
            characterImage.sprite=merlynImage;
            ability1.image.sprite=fireball;
            ability2.image.sprite=freeze;
            ability3.image.sprite=teleport;
        }
        if(PlayerPrefs.GetString("Character")=="Scarlett") //temp for getting player chosen character from database
        {
            characterField.text="Scarlett";
            characterImage.sprite=scarlettImage;
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
        Debug.Log("Menu Pressed");
        menuPanel.SetActive(!menuPanel.activeSelf);
    }

#region MenuPanel
    public void onOptionClick()   
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
        optionPanel.SetActive(!optionPanel.activeSelf);
    }

    public void OnMenuBackClick()
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
    public void OnOptionsBackClick()
    {
        //Debug.Log("Menu Pressed");
        menuPanel.SetActive(!menuPanel.activeSelf);
        optionPanel.SetActive(!optionPanel.activeSelf);
    }
#endregion
}
