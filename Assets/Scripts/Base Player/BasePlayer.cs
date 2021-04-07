using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer
{
    private string playerName;
    private int playerLevel;
    private BaseCharacter playerClass;
    private int endurance;
    private int strength;
    private int intelligence;
    private int dexterity;

    //getter and setter methods
    public string PlayerName {get;set;}
    public int PlayerLevel {get;set;}
    public BaseCharacter PlayerClass {get;set;}
    public int Endurance {get;set;}
    public int Strength {get;set;}
    public int Intelligence {get;set;}
    public int Dexterity {get;set;}
}
