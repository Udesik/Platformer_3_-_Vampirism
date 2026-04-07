using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _attackCooldown = 1f;
    private float _lastAttackTime;

    public void TryAttack(Health target)
    {
        if (Time.time >= _lastAttackTime + _attackCooldown)
        {
            Debug.Log($"Атака с уроном {_damage}");
            target.TakeDamage(_damage);
            _lastAttackTime = Time.time;
        }
    }
}
