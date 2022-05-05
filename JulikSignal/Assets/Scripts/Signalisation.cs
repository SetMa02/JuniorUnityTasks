using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalisation : MonoBehaviour
{
    [SerializeField] private float _peroidiciy = 3;  
    private AudioSource _audioSource;
    private bool _isEnter = false;
    private float _minVolume = 0;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out Thief julik))
        {
            _audioSource.Play();
            _audioSource.volume = _minVolume;
            _isEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _isEnter = false;
    }

    private void FixedUpdate()
    {
        if (_isEnter == true)
        {
            _audioSource.volume += Time.deltaTime * _peroidiciy;
        }

        if (_isEnter == false)
        {
            _audioSource.volume -= Time.deltaTime * _peroidiciy;
        }
    }
}
