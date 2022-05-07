using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Thief : MonoBehaviour
{
    [SerializeField]private GameObject _waypoint;
    [SerializeField]private GameObject _exit;
    [SerializeField] private float _step;
    
    private SpriteRenderer _spriteRenderer;
    private bool _isReached = false;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Waypoint>(out Waypoint waypoint))
        {
            _isReached = true;
            _spriteRenderer.flipX = true;
        }
    }

    private void MoveToPoint(Vector2 point)
    {
        transform.position = Vector2.Lerp(transform.position, point, _step * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (_isReached == false)
        {
            MoveToPoint(_waypoint.transform.position);
        }
        else if (_isReached == true)
        {
            MoveToPoint(_exit.transform.position);
        }
    }
}
