using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable() => Health.Changed += OnValueChanged;

    private void OnDisable() => Health.Changed -= OnValueChanged;

    protected abstract void OnValueChanged(float current, float max);
}