using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{   
    public Slider slider;

    public void setMaxHealth(int hp) {
        slider.maxValue = hp;
        slider.value = hp;
    }

    public void setHealth(int health) {
        slider.value = health;
    }
}
