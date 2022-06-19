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
    private IEnumerator _wayManager;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _wayManager = MoveToPoint(_waypoint.gameObject.transform.position);
        StartCoroutine(_wayManager);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Waypoint>(out Waypoint waypoint))
        {
            _spriteRenderer.flipX = true;
            ReachedPoint();
        }
    }

    private void ReachedPoint()
    {
        StopCoroutine(_wayManager);
        _wayManager = MoveToPoint(_exit.gameObject.transform.position);
        StartCoroutine(_wayManager);
    }

    private IEnumerator MoveToPoint(Vector2 point)
    {
        while (Vector3.Distance(transform.position, point) > float.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, point, _step * Time.deltaTime);
            yield return null;
        }
    }
}
