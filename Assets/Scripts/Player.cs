using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //temporary get functions
    public static string playerName=PlayerPrefs.GetString("Username");
    public static int level=PlayerPrefs.GetInt("Level");
    public static int Endurance=PlayerPrefs.GetInt("Endurance");
    public static int Strength=PlayerPrefs.GetInt("Strength");
    public static int Intelligence=PlayerPrefs.GetInt("Intelligence");
    public static int Dexterity=PlayerPrefs.GetInt("Dexterity");

}
