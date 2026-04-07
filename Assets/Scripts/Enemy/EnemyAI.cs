using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _viewRange = 5f;
    [SerializeField] private float _attackRange = 1.5f;
    [SerializeField] private LayerMask _playerLayer;
    
    [SerializeField] private EnemyPatrol _patrol;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Transform _target;

    private void Awake()
    {
        _patrol = GetComponent<EnemyPatrol>();
        _attacker = GetComponent<Attacker>();
    }

    private void Update()
    {
        FindTarget();

        if (_target != null)
        {
            float distance = Vector2.Distance(transform.position, _target.position);
            
            if (distance <= _attackRange)
            {
                if (_target.TryGetComponent(out Health playerHealth))
                    _attacker.TryAttack(playerHealth);
            }
            else
            {
                ChaseTarget();
            }
        }
        else
        {
            _patrol.Tick();
        }
    }

    private void FindTarget()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _viewRange, _playerLayer);
        _target = hit != null ? hit.transform : null;
    }

    private void ChaseTarget()
    {
        Vector2 direction = (_target.position - transform.position).normalized;
        transform.Translate(direction * Time.deltaTime * 1.5f);
    }
}
