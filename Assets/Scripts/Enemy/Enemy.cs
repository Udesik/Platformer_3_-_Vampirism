using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _minDistance = 0.1f;
    
    private int _currentPointIndex = 0;

    public void Tick()
    {
        if (_waypoints == null || _waypoints.Count == 0) return;

        Transform targetPoint = _waypoints[_currentPointIndex];
        
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint.position) < _minDistance)
        {
            _currentPointIndex = (_currentPointIndex + 1) % _waypoints.Count;
        }
    }
}
