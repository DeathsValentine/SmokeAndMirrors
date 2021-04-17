using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject LoginMenuPanel;
	private GameObject RegisterMenuPanel;
    private GameObject CharacterCreatePanel;

    // Start is called before the first frame update
    void Start()
    {
        LoginMenuPanel = GameObject.Find("Login Menu");
		RegisterMenuPanel = GameObject.Find("Register Menu");
        CharacterCreatePanel = GameObject.Find("CharacterCreation");

        LoginMenuPanel.SetActive(true);
        RegisterMenuPanel.SetActive(false);
        CharacterCreatePanel.SetActive(false);
    }

    #region LoginMenu
    //upon clicking filling data and login button click
    public void OnLoginClick()
    {
        //SceneManager.LoadScene("Tutorial");
        //Debug.Log("Scene Loaded");
        LoginMenuPanel.SetActive(false);
        CharacterCreatePanel.SetActive(true);
    }
    //upon clicking register button on login menu
    public void OnLoginRegisterClick()
    {
        LoginMenuPanel.SetActive(false);
        RegisterMenuPanel.SetActive(true);
    }
    #endregion

    #region RegisterMEnu
    //after filling out data and sending to database
    public void OnRegisterClick()
    {
        LoginMenuPanel.SetActive(true);
        RegisterMenuPanel.SetActive(false);
    }
    //clicking cancel button
    public void OnCancelClick()
    {
        LoginMenuPanel.SetActive(true);
        RegisterMenuPanel.SetActive(false);
    }
    #endregion


    #region CharacterCreation
 
    public void SelectMerlyn()
    {
        //temporary until database is setup
        PlayerPrefs.SetString("Character", "Merlyn");
    }

    public void SelectScarlett()
    {
        //temporary until database is setup
        PlayerPrefs.SetString("Character", "Scarlett");
    }
    public void OnSelectClick()
    {
        SceneManager.LoadScene("Tutorial");
        Debug.Log("Scene Loaded");
    }

    #endregion


    //Exit Game from Main Menu
    public void OnQuitClick()
    {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }
}
