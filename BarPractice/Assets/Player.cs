using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
   [SerializeField] private float _maxHealth;
   [SerializeField] private float _currentHealth;

   public event UnityAction<float, float> HealthChanged;

   private void Start()
   {
      _currentHealth = _maxHealth;
      HealthChanged.Invoke(_currentHealth, _maxHealth);
   }

   public void Damage(float damage)
   {
      _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
      HealthChanged.Invoke(_currentHealth, _maxHealth);
   }

   public void Heal(float health)
   {
      _currentHealth = _currentHealth = Mathf.Clamp(_currentHealth + health, 0, _maxHealth);
      HealthChanged.Invoke(_currentHealth, _maxHealth);
   }
}
