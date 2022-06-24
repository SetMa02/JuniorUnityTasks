using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private Animator _animator;
    private SpriteRenderer _sprite;
    private Vector3 _direction;
    private Rigidbody2D _rigidbody;
    private bool _isGrounded;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
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
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _animator.SetTrigger("Jump");
        }
        _animator.SetBool("IsGrounded", _isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Platform>())
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Platform>())
        {
            _isGrounded = false;
        }
    }
}
