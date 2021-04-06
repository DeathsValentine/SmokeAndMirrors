using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject LoginMenuPanel;
	private GameObject RegisterMenuPanel;

    // Start is called before the first frame update
    void Start()
    {
        LoginMenuPanel = GameObject.Find("Login Menu");
		RegisterMenuPanel = GameObject.Find("Register Menu");

        LoginMenuPanel.SetActive(true);
        RegisterMenuPanel.SetActive(false);
    }

    #region LoginMenu
    //upon clicking filling data and login button click
    public void OnLoginClick()
    {
        SceneManager.LoadScene("Tutorial");
        Debug.Log("Scene Loaded");
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
