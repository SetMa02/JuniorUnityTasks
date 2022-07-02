using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Coin : MonoBehaviour
{
    
    private Animator _animator;
    private const string Evade = "Evade";
    private Player _player;

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
        if (other.TryGetComponent<Player>(out _player))
        {
            _animator.SetTrigger(Evade);
        }
    }
}
