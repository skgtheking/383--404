using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxHealth(int health)
    {
        Debug.Log("Activated");
        slider.maxValue = health;
        Debug.Log("Activated2");
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
