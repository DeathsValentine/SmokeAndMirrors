using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter
{
    private string characterName;

    //stats
    private int endurance;
    private int strength;
    private int intelligence;
    private int dexterity;
    
    public int baseHealth=100;
    public int baseMana=100;
    public int baseManaRegen=5;


    //getter and setter methods
    public string CharacterName {get;set;}
    public int Endurance {get;set;}
    public int Strength {get;set;}
    public int Intelligence {get;set;}
    public int Dexterity {get;set;}
}
