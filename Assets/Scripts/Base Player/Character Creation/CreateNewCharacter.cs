using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewCharacter : MonoBehaviour
{
    private BasePlayer newPlayer;
    private bool isScarlett;
    private bool isMerlyn;
    // Start is called before the first frame update
    void Start()
    {
        newPlayer= new BasePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectScarlett()
    {
        newPlayer.PlayerClass=new ScarlettClass();
        newPlayer.PlayerLevel=1;
        newPlayer.Endurance=newPlayer.PlayerClass.Endurance;
        newPlayer.Strength=newPlayer.PlayerClass.Strength;
        newPlayer.Intelligence=newPlayer.PlayerClass.Intelligence;
        newPlayer.Dexterity=newPlayer.PlayerClass.Dexterity;

        //temporary till database is setup
        PlayerPrefs.SetString("Character", "Scarlett");
        PlayerPrefs.SetInt("Level", newPlayer.PlayerLevel);
        PlayerPrefs.SetInt("Endurance", newPlayer.Endurance);
        PlayerPrefs.SetInt("Strength", newPlayer.Strength);
        PlayerPrefs.SetInt("Intelligence", newPlayer.Intelligence);
        PlayerPrefs.SetInt("Dexterity", newPlayer.Dexterity);
    }
    public void SelectMerlyn()
    {
        newPlayer.PlayerClass=new MerlynClass();
        newPlayer.PlayerLevel=1;
        newPlayer.Endurance=newPlayer.PlayerClass.Endurance;
        newPlayer.Strength=newPlayer.PlayerClass.Strength;
        newPlayer.Intelligence=newPlayer.PlayerClass.Intelligence;
        newPlayer.Dexterity=newPlayer.PlayerClass.Dexterity;

        //temporary till database is setup
        PlayerPrefs.SetString("Character", "Merlyn");
        PlayerPrefs.SetInt("Level", newPlayer.PlayerLevel);
        PlayerPrefs.SetInt("Endurance", newPlayer.Endurance);
        PlayerPrefs.SetInt("Strength", newPlayer.Strength);
        PlayerPrefs.SetInt("Intelligence", newPlayer.Intelligence);
        PlayerPrefs.SetInt("Dexterity", newPlayer.Dexterity);
    }

}
