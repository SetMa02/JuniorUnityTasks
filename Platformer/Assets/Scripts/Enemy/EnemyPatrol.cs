using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(GroundDetection))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Point _leftEdge;
    [SerializeField] private Point _rightEdge;
    [SerializeField] private float _speed;
    [SerializeField] private float _waitTime;
    private Animator _animator;
    private SpriteRenderer _sprite;
    private Point _targetPoint;
    private Vector3 _direction;
    private float _currentWaitTime;
    private Rigidbody2D _rigidbody;
    private GroundDetection _detection;
    private Enemy _enemy;
    
    private void Start()
    {
        _detection = GetComponent<GroundDetection>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemy = GetComponent<Enemy>();
        _targetPoint = _leftEdge;
        _currentWaitTime = _waitTime;
    }

    private void FixedUpdate()
    {
        MoveToPoint();
    }

    private void MoveToPoint()
    {
        if (_enemy.Health >= 0 && transform.position.x != _targetPoint.transform.position.x && _detection.IsGrounded)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPoint.transform.position, _speed * Time.deltaTime); 
            _animator.SetFloat("Speed", Math.Abs(_rigidbody.velocity.x));
        }
        else if (transform.position.x >= Math.Abs(_targetPoint.transform.position.x))
        {
            _rigidbody.velocity = Vector2.zero;
            _currentWaitTime -= Time.deltaTime;
            if (_currentWaitTime <= 0)
            {
                ChangeTargetPoint();
            }
        }
    }

    private void ChangeTargetPoint()
    {
        if (_targetPoint == _leftEdge)
        {
            _targetPoint = _rightEdge;
        }
        else
        {
            _targetPoint = _leftEdge;
        }

        _currentWaitTime = _waitTime;
    }
}
