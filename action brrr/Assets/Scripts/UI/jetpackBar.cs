using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class jetpackBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxBar(float value) {
        slider.maxValue = value;
        slider.value = value;
    }

    public void setBar(float value) {
        slider.value = value;
    }
}
