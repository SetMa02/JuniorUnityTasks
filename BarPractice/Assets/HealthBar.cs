using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;
    private float _targetValue;
    private Slider _slider;
    private IEnumerator _changeValueCoroutne;
    
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
        _targetValue = value / maxValue;
        
        if (_changeValueCoroutne != null)
        {
            StopCoroutine(_changeValueCoroutne);
        }
        
        _changeValueCoroutne = ChangeValue();
        StartCoroutine(_changeValueCoroutne);
    }
    
    private IEnumerator ChangeValue()
    {
        while (_slider.value != _targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
