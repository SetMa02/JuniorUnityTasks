using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundDetection))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Point _leftEdge;
    [SerializeField] private Point _rightEdge;
    [SerializeField] private float _speed;
    private SpriteRenderer _sprite;
    private Point _targetPoint;
    private Vector3 _direction;
    private Rigidbody2D _rigidbody;
    private GroundDetection _detection;
    private Enemy _enemy;
    
    private void Start()
    {
        _detection = GetComponent<GroundDetection>();
        _sprite = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemy = GetComponent<Enemy>();
        _targetPoint = _leftEdge;
    }

    private void FixedUpdate()
    {
        MoveToPoint();
    }

    private void MoveToPoint()
    {
        if (_targetPoint == _leftEdge)
        {
            _rigidbody.velocity = Vector2.left * _speed;

            if (transform.position.x <= _targetPoint.transform.position.x)
            {
                ChangeTargetPoint();
            }
        }
        else if(_targetPoint == _rightEdge)
        {
            _rigidbody.velocity = Vector2.right * _speed;
            if (transform.position.x >= _targetPoint.transform.position.x)
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
    }
}
