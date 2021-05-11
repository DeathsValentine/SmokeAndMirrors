using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarlettClass : BaseCharacter
{
        public int enduranceVal = Player.Endurance;
        public int strengthVal = Player.Strength;
        public int intelligenceVal = Player.Intelligence;
        public int dexterityVal = Player.Dexterity;
    public ScarlettClass()
    {
        CharacterName = "Scarlett";

        Endurance =4;
        Strength=7;
        Intelligence=3;
        Dexterity=7;
    }
}
