using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Julik : MonoBehaviour
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

    private void FixedUpdate()
    {
        if (_isReached == false)
        {
            transform.position = Vector2.Lerp(transform.position, _waypoint.transform.position, _step * Time.deltaTime);
        }
        else if (_isReached == true)
        {
            transform.position = Vector2.Lerp(transform.position, _exit.transform.position, _step * Time.deltaTime);
        }
    }
}
