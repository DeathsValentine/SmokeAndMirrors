using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider slider;
    
    //set max value of health bar
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    
    //updating the bar to correct health
    public void SetHealth(int health)
    {
        slider.value=health;
    }
}
