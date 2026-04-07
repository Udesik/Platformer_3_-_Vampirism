using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : HealthView
{
    [SerializeField] protected Slider Slider;

    protected override void OnValueChanged(float current, float max)
    {
        Slider.value = current / max;
    }
}

