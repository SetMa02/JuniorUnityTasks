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
    
    private void Start()
    {
        _detection = GetComponent<GroundDetection>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _targetPoint = _leftEdge;
        _currentWaitTime = _waitTime;
        StartCoroutine(MoveToPoint());
    }

    private void FixedUpdate()
    {
        
    }

    private IEnumerator MoveToPoint()
    {
        WaitForSeconds _patrol = new WaitForSeconds(_waitTime);
        
        while (transform.position.x < Math.Abs(_targetPoint.transform.position.x))
        {
            _direction = Vector3.zero;
            _direction = Vector3.MoveTowards(transform.position, _targetPoint.transform.position,_speed * Time.deltaTime );
            _direction.y = _rigidbody.velocity.y;
            _rigidbody.velocity = _direction;
            _animator.SetFloat("Speed", Math.Abs(_direction.x));
        }

        yield return _patrol;
        
        Debug.Log("PATROL");
    }
}
