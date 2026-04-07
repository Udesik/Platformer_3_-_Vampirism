using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothHealthBar : HealthBar
{
    [SerializeField] private float _speed = 2f;
    private Coroutine _updateCoroutine;

    protected override void OnValueChanged(float current, float max)
    {
        float target = current / max;
        
        if (_updateCoroutine != null) 
            StopCoroutine(_updateCoroutine);
        
        _updateCoroutine = StartCoroutine(SmoothUpdate(target));
    }

    private IEnumerator SmoothUpdate(float targetValue)
    {
        while (!Mathf.Approximately(Slider.value, targetValue))
        {
            Slider.value = Mathf.MoveTowards(Slider.value, targetValue, _speed * Time.deltaTime);
            yield return null;
        }
    }
}