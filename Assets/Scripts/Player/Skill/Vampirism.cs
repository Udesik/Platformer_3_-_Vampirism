using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _searchRadius = 5f;
    [SerializeField] private float _healAmount = 5f;

    public void Tick()
    {
        Collider2D enemy = Physics2D.OverlapCircle(transform.position, _searchRadius, _enemyLayer);
        
        if (enemy != null && enemy.TryGetComponent(out Health enemyHealth))
        {
            enemyHealth.TakeDamage(_healAmount);
            _playerHealth.Heal(_healAmount);
        }
    }
}
