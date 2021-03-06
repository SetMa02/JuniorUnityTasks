using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
   
    [SerializeField] private float _damage;
    [SerializeField] private float _health;

    public float Health => _health;
    public float Damage => _damage;
    
}
