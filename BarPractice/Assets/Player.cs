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

   public void ApplyDamage(float damage)
   {
      _currentHealth -= damage;
      if (_currentHealth < 0)
      {
         _currentHealth = 0;
      }
      HealthChanged.Invoke(_currentHealth, _maxHealth);
   }

   public void RestoreHealth(float health)
   {
      _currentHealth += health;
      if (_currentHealth > _maxHealth)
      {
         _currentHealth = _maxHealth;
      }
      HealthChanged.Invoke(_currentHealth, _maxHealth);
   }
}
