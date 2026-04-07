using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Attacker _attacker;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _attackRadius = 3f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D enemy = Physics2D.OverlapCircle(transform.position, _attackRadius, _enemyLayer);
            
            if (enemy != null && enemy.TryGetComponent(out Health enemyHealth))
            {
                _attacker.TryAttack(enemyHealth);
            }
        }
    }
}
