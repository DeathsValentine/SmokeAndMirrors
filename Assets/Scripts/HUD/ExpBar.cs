using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ExpBar : MonoBehaviour
{
    public Slider slider;
    
    //set max value of mana bar
    public void SetMaxExp(int exp)
    {
        slider.maxValue = exp;
        slider.value = exp;
    }
    
    //updating the bar to current mana
    public void SetMana(int exp)
    {
        slider.value=exp;
    }
}
