using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{   
    public Slider slider;
    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    public void setMaxHealth(int hp) {
        slider.maxValue = hp;
        slider.value = hp;
    }

    public void setHealth(int health) {
        slider.value = health;
    }

    public void damageAnimation() {
        anim.SetTrigger("damaged");
    }

}
