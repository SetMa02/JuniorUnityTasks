using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Coin : MonoBehaviour
{
    
    private Animator _animator;

    public void EvadeCoin()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            _animator.SetTrigger("Evade");
        }
    }
}
