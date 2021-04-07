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

    private int level;

    public int baseHealth=100;
    public int baseMana=100;
    public int baseManaRegen=5;


    //getter and setter methods
    public string CharacterName
    {
        get{return characterName;}
        set{characterName=value;}
    }

    public int Endurance
    {
        get{return endurance;}
        set{endurance=value;}
    }

    public int Strength
    {
        get{return strength;}
        set{strength=value;}
    }

    public int Intelligence
    {
        get{return intelligence;}
        set{intelligence=value;}
    }

    public int Dexterity
    {
        get{return dexterity;}
        set{dexterity=value;}
    }

    public int Level
    {
        get{return level;}
        set{level=value;}
    }


}
