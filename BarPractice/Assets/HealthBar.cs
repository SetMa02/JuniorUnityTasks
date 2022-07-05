using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;
    private float _maxValue;
    private float _currentValue;
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }

    private void OnValueChanged(float value, float maxValue)
    {
        _currentValue = value;
        _maxValue = maxValue;
    }

    private void Update()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _currentValue/ _maxValue, _speed * Time.deltaTime);
    }
}
