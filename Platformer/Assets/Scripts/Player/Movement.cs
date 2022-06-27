using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(GroundDetection))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private Animator _animator;
    private SpriteRenderer _sprite;
    private Vector3 _direction;
    private Rigidbody2D _rigidbody;
    private GroundDetection _groundDetection;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundDetection = GetComponent<GroundDetection>();
    }

    private void Update()
    {
        Walk();
        Jump();
    }

    private void Walk()
    {
        _direction = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            _direction = Vector3.left;
            if (_direction.x < 0)
            {
                _sprite.flipX = true;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _direction = Vector3.right;
            if (_direction.x > 0)
            {
                _sprite.flipX = false;
            }
        }

        _direction *= _speed;
        _direction.y = _rigidbody.velocity.y;
        _rigidbody.velocity = _direction;
        _animator.SetFloat("Speed", Math.Abs(_direction.x));
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _groundDetection.IsGrounded == true)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _animator.SetTrigger("Jump");
        }
        _animator.SetBool("IsGrounded", _groundDetection.IsGrounded);
    }
}
