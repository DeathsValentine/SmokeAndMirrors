using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayFabMerger : MonoBehaviour
{
    public Text messageText;
    public InputField usernameInput;
    public InputField passwordInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RegisterButton()
    {
        if (passwordInput.text.Length < 6)
        {
            messageText.text = "Password too short";
        }

        var request = new RegisterPlayFabUserRequest
        {
            Username = usernameInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, onRegisterSuccess, onError);
    }

    void onRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and loggined in!";
    } 
    void LoginButton() 
    {
        var request = new LoginWithPlayFabRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, onSuccess, onError);
    }

    void onSuccess(LoginResult result)
    {
        Debug.Log("Successful login/ account created!");
    }

    void onError(PlayFabError err)
    {
        messageText.text = err.ErrorMessage;
        Debug.Log(err.GenerateErrorReport());
    }
}
