﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManaBar : MonoBehaviour
{
    public Slider slider;
    
    //set max value of mana bar
    public void SetMaxMana(int mana)
    {
        slider.maxValue = mana;
        slider.value = mana;
    }
    
    //updating the bar to current mana
    public void SetMana(int mana)
    {
        slider.value=mana;
    }
}
