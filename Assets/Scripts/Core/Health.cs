using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue = 100f;
    private float _currentValue;

    public event UnityAction<float, float> Changed;

    private void Awake()
    {
        _currentValue = _maxValue;
    }

    private void Start()
    {
        Changed?.Invoke(_currentValue, _maxValue);
    }

    public void TakeDamage(float damage)
    {
        _currentValue = Mathf.Max(_currentValue - damage, 0);
        Changed?.Invoke(_currentValue, _maxValue);
    }

    public void Heal(float amount)
    {
        _currentValue = Mathf.Min(_currentValue + amount, _maxValue);
        Changed?.Invoke(_currentValue, _maxValue);
    }
}