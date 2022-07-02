using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundDetection))]
public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private List<Point> _points;
    [SerializeField] private float _speed;
    private Point _targetPoint;
    private Vector3 _direction;
    private GroundDetection _detection;
    private int _nextPoint;

    private void Start()
    {
        _detection = GetComponent<GroundDetection>();
        _targetPoint = _points[0];
    }

    private void OnEnable()
    {
        foreach (var point in _points)
        {
            point.Reched += ChangeTargetPoint;
        }
    }

    private void OnDisable()
    {
        foreach (var point in _points)
        {
            point.Reched -= ChangeTargetPoint;
        }
    }

    private void FixedUpdate()
    {
        MoveToPoint();
    }

    private void MoveToPoint()
    {
        if (_detection.IsGrounded == true)
        {
            _direction = transform.position;
            _direction = Vector3.MoveTowards(_direction, _targetPoint.transform.position, _speed * Time.deltaTime);
            transform.position = new Vector3(_direction.x, transform.position.y, transform.position.z);
        }
    }

    private void ChangeTargetPoint()
    {
        _nextPoint = _points.IndexOf(_targetPoint);
        _nextPoint++;
        if (_nextPoint == _points.Capacity)
        {
            _nextPoint = 0;
        }

        Debug.Log(_nextPoint);
        _targetPoint = _points[_nextPoint];
    }
}