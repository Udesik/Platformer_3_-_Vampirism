using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rb;
    
    [SerializeField] private InputReader _input;
    [SerializeField] private GroundChecker _ground;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private PlayerAnimator _view;

    private void OnEnable()
    {
        _input.JumpRequested += TryJump;
    }

    private void OnDisable()
    {
        _input.JumpRequested -= TryJump;
    }

    private void Update()
    {
        float direction = _input.Direction;
        _rb.velocity = new Vector2(direction * _speed, _rb.velocity.y);
        
        _view.UpdateSpeed(direction);
        _view.Flip(direction);
    }

    private void TryJump()
    {
        if (_ground.IsGrounded)
            _jumper.Jump();
    }
}