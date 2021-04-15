using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    private GameObject bottomBar;
    private GameObject menuPanel;

    void Start()
    {
        bottomBar = GameObject.Find("BottomBar");
        menuPanel = GameObject.Find("MenuPanel");

        bottomBar.SetActive(true);
        menuPanel.SetActive(false);
    }

    void Update()
    {
        //when escape key on keyboard is pressed show menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("Escape Pressed");
            menuPanel.SetActive(!menuPanel.activeSelf);
        }
    }

    public void OnMenuCall()
    {
        //Debug.Log("Menu Pressed");
        menuPanel.SetActive(!menuPanel.activeSelf);
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
}
