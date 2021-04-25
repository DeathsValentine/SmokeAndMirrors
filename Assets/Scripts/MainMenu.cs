using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour
{
    private GameObject LoginMenuPanel;
	private GameObject RegisterMenuPanel;
    private GameObject CharacterCreatePanel;
    //public InputField test;
    
    private GameObject loginError;
    private GameObject registerError;

    private Text loginText;
    private Text registerText;

    // Start is called before the first frame update
    void Start()
    {
        LoginMenuPanel = GameObject.Find("Login Menu");
		RegisterMenuPanel = GameObject.Find("Register Menu");
        CharacterCreatePanel = GameObject.Find("CharacterCreation");

        //errors when login/regsiter
        loginError=GameObject.Find("LoginError");
        registerError=GameObject.Find("RegisterError");

        loginText=loginError.GetComponent<Text>();
        registerText=registerError.GetComponent<Text>();

        LoginMenuPanel.SetActive(true);
        RegisterMenuPanel.SetActive(false);
        CharacterCreatePanel.SetActive(false);

        loginError.SetActive(false);
        registerError.SetActive(false);
    }
    

    #region LoginMenu
    //upon clicking filling data and login button click
    public void OnLoginClick()
    {
        //SceneManager.LoadScene("Tutorial");
        //Debug.Log("Scene Loaded");
        InputField[] inputs = LoginMenuPanel.GetComponentsInChildren<InputField>();
  
        var request = new LoginWithPlayFabRequest
        {
            Username = inputs[0].text,
            Password = inputs[1].text,
        };
        PlayFabClientAPI.LoginWithPlayFab(request, onLoginSuccess, onError);
        PlayerPrefs.SetString("Username",inputs[0].text);
    }

    //upon clicking register button on login menu
    public void OnLoginRegisterClick()
    {
        LoginMenuPanel.SetActive(false);
        RegisterMenuPanel.SetActive(true);
    }

    //Returns prints out that Login was successfull on the console log
    void onLoginSuccess(LoginResult result)
    {
        Debug.Log("Successful login");
        LoginMenuPanel.SetActive(false);
        CharacterCreatePanel.SetActive(true);
        loginError.SetActive(false);
    }

    #endregion

    #region RegisterMEnu
    //after filling out data and sending to database
    public void OnRegisterClick()
    {
        InputField[] inputs = RegisterMenuPanel.GetComponentsInChildren<InputField>();
        var usernameInput = inputs[0];
        var passwordInput = inputs[1];
        var passwordInput2 = inputs[2];

        
        if (passwordInput.text.Length < 6)
        {
            registerError.SetActive(true);
            Debug.Log("Password too short");
            registerText.text="Password too Short (Must Be More Than 6 Characters/Numbers)";
        }
        else if (!passwordInput.Equals(passwordInput2))
        {
            registerError.SetActive(true);
            Debug.Log("Passwords dont match");
            registerText.text="Passwords Don't Match";
        }
        else
        {
            registerError.SetActive(false);
            var request = new RegisterPlayFabUserRequest
            {
                Username = usernameInput.text,
                Password = passwordInput.text,
                RequireBothUsernameAndEmail = false
            };
            PlayFabClientAPI.RegisterPlayFabUser(request, onRegisterSuccess, onError);
        }
    }

    private void onRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Registered and Logged in!");
        RegisterMenuPanel.SetActive(false);
        CharacterCreatePanel.SetActive(true);
    }

    //clicking cancel button
    public void OnCancelClick()
    {
        LoginMenuPanel.SetActive(true);
        RegisterMenuPanel.SetActive(false);
    }
    #endregion


    void onError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
        if(LoginMenuPanel.activeSelf==true)
        {
            loginError.SetActive(true);
            loginText.text="Invalid Username or Password";
        }
    }

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
